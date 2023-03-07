import { APP_INITIALIZER, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './orders.component';
import { OrdersService } from './orders.service';
import { ReactiveFormsModule } from '@angular/forms';

export interface OrderStatus {
  displayName: string;
  value: string;
}

export const ORDER_STATUSES: OrderStatus[] = [
  { displayName: 'Registered', value: 'REGISTERED' },
  { displayName: 'In preparation', value: 'PREPARATION' },
  { displayName: 'Ready to be delivered', value: 'READY_TO_BE_DELIVERED' },
  { displayName: 'Delivered', value: 'DELIVERED' },
];

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  declarations: [OrdersComponent],
  providers: [
    OrdersService, {
      provide: APP_INITIALIZER,
      useFactory: (pizzasService: OrdersService) => () => pizzasService.allForSelect().toPromise(),
      deps: [OrdersService],
      multi: true
    }
  ]
})
export class OrdersModule { }
