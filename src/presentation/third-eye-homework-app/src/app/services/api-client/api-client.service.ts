import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../components/factories/api-base-url.provide';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {
  private readonly baseUrl = inject(API_BASE_URL);
  private http = inject(HttpClient);

  testBackendCall(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/WeatherForecast`);
  }
}
