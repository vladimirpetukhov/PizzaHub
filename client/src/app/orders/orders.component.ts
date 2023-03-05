import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PizzaTypeSelect } from '../pizzas/pizza';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  pizzaTypes$!: Observable<PizzaTypeSelect[]>;

  constructor(private orderService: OrdersService) { }

  ngOnInit() {
    this.pizzaTypes$ = this.orderService.allForSelect();
  }

}
