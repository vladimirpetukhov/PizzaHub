import { APP_INITIALIZER, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './orders.component';
import { OrdersService } from './orders.service';

@NgModule({
  imports: [
    CommonModule
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
