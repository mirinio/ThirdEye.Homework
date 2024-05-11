import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { API_BASE_URL } from '../../factories/api-base-url.provide';
import { ScenarioSpace } from '../../models/scenario-space.model';
import { ScenarioSpaceSummary } from '../../models/scenario-space-summary.model';
import { AlphaSimulationData, PortfoliosSimulation } from '../../models/portfolio-simulation.model';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {
  private readonly baseUrl = inject(API_BASE_URL);
  private http = inject(HttpClient);
  private readonly headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');

  getScenarioSpaces(): Observable<ScenarioSpace[]> {
    return this.http.get<ScenarioSpace[]>(`${this.baseUrl}/ScenarioSpace`);
  }

  getScenarioSpaceSummaryByName(name:string): Observable<ScenarioSpaceSummary> {
    return this.http.get<ScenarioSpaceSummary>(`${this.baseUrl}/ScenarioSpace/Summary`,{
      params: new HttpParams().set('name', name)
    });
  }

  simulatePortfolio(portfolioSimulation: PortfoliosSimulation, name: string): Observable<AlphaSimulationData> {
    return this.http.post<AlphaSimulationData>(`${this.baseUrl}/Simulation`, portfolioSimulation, {
      headers: this.headers,
      observe: 'body',
      responseType: 'json',
      params: new HttpParams().set('name', name)
    });
  }
}
