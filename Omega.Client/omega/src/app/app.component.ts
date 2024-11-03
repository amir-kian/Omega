import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Router, RouterModule, Routes } from '@angular/router';
import { bootstrapApplication } from '@angular/platform-browser';
import { ServiceDetailsComponent } from './service-details/service-details.component';

@Component({
selector: 'app-root',
standalone: true,
imports: [HttpClientModule, CommonModule, RouterModule],
templateUrl: './app.component.html',
styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
data: any;

constructor(private apiService: ApiService, private router: Router) {}

ngOnInit() {
this.apiService.getAllItems().subscribe(
(response) => {
this.data = response;
},
(error) => {
console.error('Error fetching data', error);
}
);
}

navigateToDetails(serviceId: number) {
this.router.navigate(['/service-details', serviceId]);
}
}

const routes: Routes = [
{ path: 'service-details/:id', component: ServiceDetailsComponent },
// other routes
];

bootstrapApplication(AppComponent, {
providers: [
{ provide: ApiService, useClass: ApiService },
{ provide: RouterModule, useValue: RouterModule.forRoot(routes) },
{ provide: HttpClientModule, useValue: HttpClientModule }
]
});