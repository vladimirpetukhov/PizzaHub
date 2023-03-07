import { OrdersService } from 'src/app/orders/orders.service'
import {  OrderForResponse, OrderForUpdateRequest } from './../../shared/types/order'
import { Component, OnInit } from '@angular/core';
import { OrderStatus, ORDER_STATUSES } from '../orders.module';

@Component({
  selector: 'app-orders-dashboard',
  templateUrl: './orders-dashboard.component.html',
  styleUrls: ['./orders-dashboard.component.css']
})
export class OrdersDashboardComponent implements OnInit {

  orderStatuses: OrderStatus[] = ORDER_STATUSES;

  orders: OrderForResponse[] = [];

  public updateOrder: OrderForUpdateRequest = {
    status: '',
    quantity: 0
  };

  page: number = 1;
  totalPages: number = 1;

  isNewRowVisible = false;
  editedIndex = -1;
  isEditing = false;

  constructor(private orderService: OrdersService) { }

  ngOnInit() {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService.all(this.page, undefined ).subscribe((res) => {
      this.orders = res.orders;
      this.totalPages = res.totalPages;
    }, error => {
      console.log(error);
    });
  }

  addNewPizza() {
    this.isNewRowVisible = true;
  }

  editPizza(index: number) {
    console.log(index);
    this.editedIndex = index;
  }

  cancelEdit() {
    console.log('cancel');
    this.editedIndex = -1;
  }

  saveEdit(index: number, pizza: OrderForResponse) {
    // this.pizzaService.update(pizza.id, pizza).subscribe((res) => {
    //   this.loadPizzas();
    // }, error => {
    //   console.log(error);
    // });
    this.editedIndex = -1;
  }

  // saveNewPizza() {
  //   this.pizzaService.create(this.newPizza).subscribe((res) => {
  //     this.loadPizzas();
  //   }, error => {
  //     console.log(error);
  //   });
  //   this.newPizza = { id: 0, name: '', price: 0, description: '' };
  //   this.isNewRowVisible = false;
  // }

  // cancelNewPizza() {
  //   this.isNewRowVisible = false;
  //   this.newPizza = { id: 0, name: '', price: 0, description: '' };
  // }

  nextPage() {
    if (this.page < this.totalPages) {
      this.page++;
      this.loadOrders();
    }
  }

  previousPage() {
    if (this.page > 1) {
      this.page--;
      this.loadOrders();
    }
  }

  goToPage(pageNumber: number) {
    if (pageNumber >= 1 && pageNumber <= this.totalPages) {
      this.page = pageNumber;
      this.loadOrders();
    }
  }

  delete(id: number) {
    // const index = this.pizzas.findIndex(p => p.id === id);
    // if (index === -1) {
    //   console.log('Pizza not found');
    //   return;
    // }
    // this.pizzaService.delete(id).subscribe((res) => {
    //   this.loadPizzas();
    // }, error => {
    //   console.log(error);
    // });
  }

}
