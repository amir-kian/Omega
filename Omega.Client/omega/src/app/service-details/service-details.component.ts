import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
selector: 'app-service-details',
templateUrl: './service-details.component.html',
styleUrls: ['./service-details.component.css']
})
export class ServiceDetailsComponent implements OnInit {
serviceId!: number;
serviceDetails: any;

constructor(private route: ActivatedRoute, private apiService: ApiService) {}

ngOnInit(): void {
this.route.params.subscribe(params => {
this.serviceId = +params['id']; 
this.fetchServiceDetails();
});
}

fetchServiceDetails(): void {
if (this.serviceId !== undefined) {
this.apiService.getServiceDetails(this.serviceId).subscribe(
(response) => {
this.serviceDetails = response;
},
(error) => {
console.error('Error fetching service details', error);
}
);
}
}
}