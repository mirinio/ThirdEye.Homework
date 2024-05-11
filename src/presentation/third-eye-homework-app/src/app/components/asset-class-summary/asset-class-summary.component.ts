import { ChangeDetectionStrategy, Component, inject, Input } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { PortfolioAsset, PortfoliosSimulation } from '../../models/portfolioSimulation.model';
import { ApiClientService } from '../../services/api-client/api-client.service';


export interface AssetClassSummary {
  name: string;
  allocation: number;
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
    ButtonModule
  ],
  templateUrl: './asset-class-summary.component.html',
  styleUrl: './asset-class-summary.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AssetClassSummaryComponent {

  private readonly apiClient = inject(ApiClientService);
  private fb = inject(FormBuilder);
  protected form = this.fb.array<FormGroup<AssetClassGroup>>([]);

  @Input() set assetClasses(assetClasses: AssetClassSummary[] | null) {
    if (!assetClasses) return;
    this.form.clear();

    assetClasses.forEach(asset => {
        this.form.controls.push(this.createAssetClassGroup(asset));
      }
    );
  }

  simulate(): void {
    const simulation = this.createPortfolio();
    this.apiClient.simulatePortfolio(simulation);
  }

  private createAssetClassGroup(asset: AssetClassSummary): FormGroup<AssetClassGroup> {
    return this.fb.group<AssetClassGroup>({
      assetName: this.fb.control<string | null>({ value: asset.name, disabled: true }),
      allocation: this.fb.control<number | null>(asset.allocation)
    });
  }


  private createPortfolio(): PortfoliosSimulation {
    const assets = this.form.controls.map<PortfolioAsset>(group => ({
      asset_class: group.value.assetName ?? '',
      initial_allocation: group.value.allocation ?? 0,
      asset_mgmt_fee: 0.0015,
      initial_load_fee: 0
    }));

    return {
      portfolios: {
        name: 'test',
        assets: assets,
        rebalancing_frequency: 2,
        cash_asset_class_name: 'CS_EUR',
        portfolio_mgmt_fee: 0,
        liquid: true,
        capital_gain_tax_rate: 0.15,
        income_tax_rate: 0.15,
        max_credit_fraction: 0.5
      },
      goal_percentiles: [5, 50],
      wealth_returns: [50],
      scenarios: 1000,
      total_quarters: 156,
      active_quarters: 185,
      percentiles: [5, 50, 75]
    };
  }
}
