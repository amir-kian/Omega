import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
selector: 'app-root',
standalone: true,
imports: [HttpClientModule, CommonModule, RouterModule],
templateUrl: './app.component.html',
styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
data: any;

constructor(private apiService: ApiService) {}

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
}