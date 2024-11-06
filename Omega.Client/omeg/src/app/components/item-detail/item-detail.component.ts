import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../../services/app-service.service';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-item-details',
    templateUrl: './item-detail.component.html',
    styleUrls: ['./item-detail.component.css'],
    standalone: true,
    imports: [CommonModule]
})
export class ItemDetailsComponent implements OnInit {
    item: any;

    constructor(private route: ActivatedRoute, private apiService: ApiService, private cdr: ChangeDetectorRef) { }

    ngOnInit() {
        const itemId = this.route.snapshot.paramMap.get('id');
        if (itemId !== null) {
            const itemIdNumber = Number(itemId);
            this.apiService.getServiceDetails(itemIdNumber).subscribe(
                (response) => {
                    this.item = response;
                    console.log(response);
                    this.cdr.detectChanges(); // Manually trigger change detection
                },
                (error) => {
                    console.error('Error fetching item details', error);
                }
            );
        } else {
            console.error('Item ID is null');
        }
    }
}