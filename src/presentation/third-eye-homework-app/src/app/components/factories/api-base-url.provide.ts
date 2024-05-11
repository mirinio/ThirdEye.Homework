import { InjectionToken } from "@angular/core";

export function apiBaseUrlFactory(): string {
  if (/localhost:4200/.test(window.location.origin)) {
    return 'https://localhost:44355/api';
  }

  return 'https://api.' + window.location.hostname;
}

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');