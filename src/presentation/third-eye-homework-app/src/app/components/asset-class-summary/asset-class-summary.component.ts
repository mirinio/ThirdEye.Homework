import { ChangeDetectionStrategy, Component, inject, Input, OnInit } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { PortfolioAsset, PortfoliosSimulation } from '../../models/portfolio-simulation.model';
import { ApiClientService } from '../../services/api-client/api-client.service';
import { BehaviorSubject, first, map, tap } from 'rxjs';
import { AssetClassCashType } from '../../models/scenario-space.model';
import { CardModule } from 'primeng/card';
import { ChartModule } from 'primeng/chart';
import { range } from 'lodash-es';

export interface ScenarioAssetClassesSummary {
  name: string;
  cashType: AssetClassCashType;
  assetClasses: AssetClassAllocation[];
}

export interface AssetClassAllocation {
  name: string;
  allocation: number;
}

export interface Chart {
  labels: string[];
  datasets: ChartDataSet[];
}

export interface ChartDataSet {
  label: string;
  data: number[];
  tension: number;
  fill: boolean;
}

export interface AssetClassGroup {
  assetName: FormControl<string | null>;
  allocation: FormControl<number | null>;
}

@Component({
  selector: 'app-asset-class-summary',
  standalone: true,
  imports: [
    AsyncPipe,
    ReactiveFormsModule,
    InputNumberModule,
    InputTextModule,
    ButtonModule,
    CardModule,
    ChartModule
  ],
  templateUrl: './asset-class-summary.component.html',
  styleUrl: './asset-class-summary.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AssetClassSummaryComponent implements OnInit {

  private readonly apiClient = inject(ApiClientService);
  private fb = inject(FormBuilder);
  protected form = this.fb.array<FormGroup<AssetClassGroup>>([]);
  private documentStyle = getComputedStyle(document.documentElement);
  protected scenarioSpaceSubject = new BehaviorSubject<{
    name: string;
    cashType: AssetClassCashType
  } | undefined>(undefined);

  protected chartData$ = new BehaviorSubject<Chart | undefined>(undefined);

  data: any;
  options: any;

  @Input() set assetClasses(scenario: ScenarioAssetClassesSummary | null) {
    if (!scenario || !scenario.assetClasses.length) return;

    this.form.clear();
    this.scenarioSpaceSubject.next({ name: scenario.name, cashType: scenario.cashType });
    scenario.assetClasses.forEach(asset => {
        this.form.controls.push(this.createAssetClassGroup(asset));
      }
    );
    this.form.updateValueAndValidity();
  }


  ngOnInit() {


    const textColor = this.documentStyle.getPropertyValue('--text-color');
    const textColorSecondary = this.documentStyle.getPropertyValue('--text-color-secondary');
    const surfaceBorder = this.documentStyle.getPropertyValue('--surface-border');

    this.options = {
      maintainAspectRatio: false,
      aspectRatio: 0.6,
      plugins: {
        legend: {
          labels: {
            color: textColor
          }
        }
      },
      scales: {
        x: {
          ticks: {
            color: textColorSecondary
          },
          grid: {
            color: surfaceBorder,
            drawBorder: false
          }
        },
        y: {
          ticks: {
            color: textColorSecondary
          },
          grid: {
            color: surfaceBorder,
            drawBorder: false
          }
        }
      }
    };
  }

  simulate(): void {
    if (this.scenarioSpaceSubject.value && this.form.controls.length) {
      console.log(this.scenarioSpaceSubject.value);
      const simulation = this.createPortfolio(this.scenarioSpaceSubject.value.cashType);
      this.apiClient.simulatePortfolio(simulation, this.scenarioSpaceSubject.value.name)
        .pipe(first(), tap((x) => console.log(x)),map((data) => {
          const totals = Object.keys(data.wealth.total).map<ChartDataSet>(key => ({
            label: `wealth-total-${key}`,
            data: data.wealth.total[key],
            fill: false,
            tension: 0.4,
          }));

          const loans = Object.keys(data.wealth.loans).map<ChartDataSet>(key => ({
            label: `wealth-loans-${key}`,
            data: data.wealth.loans[key],
            fill: false,
            tension: 0.4,
          }));

          return [...totals, ...loans];
        })).subscribe(data => this.chartData$.next({
        labels: range(1,157).map(String),
        datasets: data
      }));
    }
  }

  private createAssetClassGroup(asset: AssetClassAllocation): FormGroup<AssetClassGroup> {
    return this.fb.group<AssetClassGroup>({
      assetName: this.fb.control<string | null>({ value: asset.name, disabled: true }),
      allocation: this.fb.control<number | null>(asset.allocation)
    });
  }

  private createPortfolio(cashType: AssetClassCashType): PortfoliosSimulation {
    const assets = this.form.controls.map<PortfolioAsset>(group => ({
      asset_class: group.controls.assetName.value ?? '',
      initial_allocation: group.controls.allocation.value ?? 0,
      asset_mgmt_fee: 0.0015,
      initial_load_fee: 0
    }));

    return {
      portfolios: [{
        name: 'test',
        assets: assets,
        rebalancing_frequency: 2,
        cash_asset_class_name: cashType.toString(),
        portfolio_mgmt_fee: 0,
        liquid: true,
        capital_gain_tax_rate: 0.15,
        income_tax_rate: 0.15,
        max_credit_fraction: 0.5
      }],
      goal_percentiles: [5, 50],
      wealth_returns: [50],
      scenarios: 1000,
      total_quarters: 156,
      active_quarters: 185,
      percentiles: [5, 50, 75]
    };
  }
}
