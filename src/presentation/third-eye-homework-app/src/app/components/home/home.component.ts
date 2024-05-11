import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { ApiClientService } from '../../services/api-client/api-client.service';
import { AsyncPipe } from '@angular/common';
import { CardModule } from 'primeng/card';
import { BehaviorSubject, map, Observable, of, switchMap } from 'rxjs';
import { AssetClassSummary, AssetClassSummaryComponent } from '../asset-class-summary/asset-class-summary.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    ButtonModule,
    ChartModule,
    AsyncPipe,
    CardModule,
    AssetClassSummaryComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit {
  data: any;
  options: any;

  private readonly apiClient = inject(ApiClientService);
  protected readonly scenarioSpaces$ = this.apiClient.getScenarioSpaces();
  protected readonly scenarioSpaceSubject = new BehaviorSubject<string | undefined>(undefined);
  protected readonly assetClasses$: Observable<AssetClassSummary[]> = this.scenarioSpaceSubject.pipe(switchMap(name => {
    if (!name) return of([]);
    console.log(name);
    return this.apiClient.getScenarioSpaceSummaryByName(name).pipe(map(summary =>
      Object.keys(summary.asset_classes).map<AssetClassSummary>(asset => ({ name: asset, allocation: 0 }))));
  }));

  ngOnInit() {

    const documentStyle = getComputedStyle(document.documentElement);
    const textColor = documentStyle.getPropertyValue('--text-color');
    const textColorSecondary = documentStyle.getPropertyValue('--text-color-secondary');
    const surfaceBorder = documentStyle.getPropertyValue('--surface-border');

    this.data = {
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
        {
          label: 'First Dataset',
          data: [65, 59, 80, 81, 56, 55, 40],
          fill: false,
          borderColor: documentStyle.getPropertyValue('--blue-500'),
          tension: 0.4
        },
        {
          label: 'Second Dataset',
          data: [28, 48, 40, 19, 86, 27, 90],
          fill: false,
          borderColor: documentStyle.getPropertyValue('--pink-500'),
          tension: 0.4
        }
      ]
    };

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

  loadSummary(name: string) {
    this.scenarioSpaceSubject.next(name);
  }
}