import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/app-service.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-item-list',
    templateUrl: './item-list.component.html',
    styleUrls: ['./item-list.component.css'],
    standalone: true,
    imports: [CommonModule]
})
export class ItemListComponent implements OnInit {
    items!: any[];

    constructor(private apiService: ApiService, private router: Router) { }

    ngOnInit() {
        this.apiService.getAllItems().subscribe(
            (response) => {
                console.log('API response:', response); // Debugging line
                this.items = response.data; // Access the data property
            },
            (error) => {
                console.error('Error fetching items', error);
            }
        );
    }

    navigateToDetails(itemId: number) {
        this.router.navigate(['/item-details', itemId]);
    }
}