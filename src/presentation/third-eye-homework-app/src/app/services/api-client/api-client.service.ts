import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../components/factories/api-base-url.provide';
import { ScenarioSpace } from '../../models/ScenarioSpace.model';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {
  private readonly baseUrl = inject(API_BASE_URL);
  private http = inject(HttpClient);

  getScenarioSpaces(): Observable<ScenarioSpace[]> {
    return this.http.get<ScenarioSpace[]>(`${this.baseUrl}/ScenarioSpace`);
  }

}
