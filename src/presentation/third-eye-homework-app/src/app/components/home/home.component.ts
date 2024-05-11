import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { ApiClientService } from '../../services/api-client/api-client.service';
import { AsyncPipe } from '@angular/common';
import { CardModule } from 'primeng/card';
import { BehaviorSubject, combineLatest, EMPTY, map, Observable, of, switchMap } from 'rxjs';
import {
  AssetClassAllocation,
  AssetClassSummaryComponent,
  ScenarioAssetClassesSummary
} from '../asset-class-summary/asset-class-summary.component';
import { ScenarioSpace } from '../../models/scenario-space.model';
import { TagModule } from 'primeng/tag';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    ButtonModule,
    ChartModule,
    AsyncPipe,
    CardModule,
    AssetClassSummaryComponent,
    TagModule
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent {

  private readonly apiClient = inject(ApiClientService);
  protected readonly scenarioSpaces$ = this.apiClient.getScenarioSpaces();
  protected readonly scenarioSpaceSubject = new BehaviorSubject<ScenarioSpace | undefined>(undefined);
  protected readonly scenarioAssetClassSummary$: Observable<ScenarioAssetClassesSummary> = this.scenarioSpaceSubject.pipe(switchMap(scenario => {
    if (!scenario) return EMPTY;

    return combineLatest([this.apiClient.getScenarioSpaceSummaryByName(scenario.name), of(scenario)]).pipe(map(([summary, scenario]) => (<ScenarioAssetClassesSummary>{
      name: scenario.name,
      cashType: scenario.assetClassCashType,
      assetClasses: Object.keys(summary.asset_classes).map<AssetClassAllocation>(asset => ({
        name: asset,
        allocation: 0
      }))
    })));
  }));

  loadSummary(scenario: ScenarioSpace) {
    this.scenarioSpaceSubject.next(scenario);
  }
}