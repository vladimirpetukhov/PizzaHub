import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Pizza, PizzasResponse } from './pizza';
import { Observable } from 'rxjs';

@Injectable()
export class PizzasService {

constructor(private http: HttpClient) { }

getPizzas(pageNumber?: number, query?: string): Observable<PizzasResponse> {
  let params = new HttpParams();

  if (pageNumber) {
    params.set('page', pageNumber.toString());
  }

  if (query) {
    params.set('quey', query);
  }
    return this.http.get<PizzasResponse>('pizzas', { params });
  }

}
