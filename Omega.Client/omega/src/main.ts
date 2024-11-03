import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideRouter } from '@angular/router';
import { appRoutes } from './app/app.routes';
import { provideHttpClient } from '@angular/common/http';
import { ApiService } from './app/api.service';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(appRoutes), // Correct way to provide routes
    provideHttpClient(),      // Correct way to provide HttpClientModule
    ApiService,               // Providing your service
  ],
});
