import { OrderForRequest } from './../shared/types/order'
import { PizzaTypeForResponse } from './../pizzas/pizza'
import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { PizzaTypeSelect } from '../pizzas/pizza';
import { Order } from '../shared/types/order';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  private pizzaTypes: PizzaTypeSelect[] = [];
  private pizzaTypes$ = new BehaviorSubject<PizzaTypeSelect[]>(this.pizzaTypes);

  constructor(private http: HttpClient) { }

  createOrder(order: OrderForRequest) {
    return this.http.post('orders', order);
  }

  allForSelect(): Observable<PizzaTypeSelect[]> {
    return this.http.get<PizzaTypeForResponse>('pizzas/all').pipe(map( response=> response.pizzas ));
  }

}
