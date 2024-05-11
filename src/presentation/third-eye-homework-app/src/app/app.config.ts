import { ApplicationConfig, makeEnvironmentProviders } from '@angular/core';
import { provideRouter } from '@angular/router';
import { appRoutes } from './app.routes';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideHttpClient } from '@angular/common/http';
import { API_BASE_URL, apiBaseUrlFactory } from './components/factories/api-base-url.provide';


export const appConfig: ApplicationConfig = {
  providers: [provideRouter(appRoutes), [
    provideAnimations(),
    provideHttpClient(),
    makeEnvironmentProviders([
      { provide: API_BASE_URL, useFactory: apiBaseUrlFactory }
    ])
  ]],
};
