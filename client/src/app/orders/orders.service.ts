import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { PizzaTypeSelect } from '../pizzas/pizza';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  private pizzaTypes: PizzaTypeSelect[] = [];
  private pizzaTypes$ = new BehaviorSubject<PizzaTypeSelect[]>(this.pizzaTypes);

  constructor(private http: HttpClient) { }

  allForSelect(): Observable<PizzaTypeSelect[]> {
    return this.http.get<PizzaTypeSelect[]>('pizzas/all');
  }

}
