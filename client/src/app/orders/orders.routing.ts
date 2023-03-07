import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrdersDashboardComponent } from './orders-dashboard/orders-dashboard.component';
import { OrdersComponent } from './orders.component';

const routes: Routes = [
  {
    path: 'create',
    component: OrdersComponent
   },
  {
    path: 'dashboard',
    component: OrdersDashboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrdersRoutes {}
