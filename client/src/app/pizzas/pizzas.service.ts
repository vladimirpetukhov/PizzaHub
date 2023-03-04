import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Pizza, PizzasResponse, PizzaForRequest } from './pizza';
import { Observable } from 'rxjs';

@Injectable()
export class PizzasService {

  constructor(private http: HttpClient) { }

  all(pageNumber?: number, query?: string): Observable<PizzasResponse> {
    let params = new HttpParams();

    if (pageNumber) {
      params = params.set('page', pageNumber.toString());
    }

    if (query) {
      params = params.set('quey', query);
    }
    console.log(params)
    console.log(pageNumber);
    return this.http.get<PizzasResponse>('pizzas', { params });
  }

  create(pizza: PizzaForRequest) {
    return this.http.post('pizzas', pizza);
  }

  update(id: number, pizza: PizzaForRequest) {
    return this.http.put(`pizzas/${id}`, pizza);
  }

  delete(id: number) {
    return this.http.delete(`pizzas/${id}`);
  }

}
