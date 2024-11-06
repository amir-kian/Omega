import { Routes } from '@angular/router';
import { ItemListComponent } from './components/item-list/item-list.component'; 
import { ItemDetailsComponent } from './components/item-detail/item-detail.component'; 

export const routes: Routes = [
{ path: '', component: ItemListComponent },
{ path: 'item-details/:id', component: ItemDetailsComponent }
];