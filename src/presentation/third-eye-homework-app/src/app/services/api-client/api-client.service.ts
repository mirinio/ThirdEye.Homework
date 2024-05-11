import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { API_BASE_URL } from '../../factories/api-base-url.provide';
import { ScenarioSpace } from '../../models/scenario-space.model';
import { ScenarioSpaceSummary } from '../../models/scenario-space-summary.model';
import { PortfoliosSimulation } from '../../models/portfolioSimulation.model';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {
  private readonly baseUrl = inject(API_BASE_URL);
  private http = inject(HttpClient);

  getScenarioSpaces(): Observable<ScenarioSpace[]> {
    return this.http.get<ScenarioSpace[]>(`${this.baseUrl}/ScenarioSpace`);
  }

  getScenarioSpaceSummaryByName(name:string): Observable<ScenarioSpaceSummary> {
    return this.http.get<ScenarioSpaceSummary>(`${this.baseUrl}/ScenarioSpace/Summary`,{
      params: new HttpParams().set('name', name)
    });
  }

  simulatePortfolio(portfolioSimulation: PortfoliosSimulation): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/ScenarioSpace/Summary`, portfolioSimulation);
  }
}
