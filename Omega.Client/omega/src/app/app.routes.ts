import { Routes } from '@angular/router';
import { ServiceDetailsComponent } from './service-details/service-details.component';

export const appRoutes: Routes = [
  // Remove this line: { path: '', component: AppComponent },
  { path: 'service-details/:id', component: ServiceDetailsComponent },
  // You can add other routes here, e.g., for a home or not-found page
];
