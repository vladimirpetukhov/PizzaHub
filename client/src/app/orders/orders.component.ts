import { CustomerForRequest } from './../shared/types/customer'
import { PizzaTypeForResponse } from './../pizzas/pizza'
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Observable, tap } from 'rxjs';
import { PizzaTypeSelect } from '../pizzas/pizza';
import { Order, OrderForRequest } from '../shared/types/order';
import { OrderStatus, ORDER_STATUSES } from './orders.module';
import { OrdersService } from './orders.service';
import { PhoneExistsValidator } from '../core/validators/phoneExistsValidator';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  pizzaTypes$!: Observable<PizzaTypeSelect[]>;

  orderForm: FormGroup;
  order: Order;
  orderStatuses: OrderStatus[] = ORDER_STATUSES;
  // customer: Customer = new Customer();
  // pizzaTypes: PizzaType[] = [];

  constructor(private orderService: OrdersService, private fb: FormBuilder, private phoneValidator: PhoneExistsValidator) {
    this.order = {} as Order;

    this.orderForm = this.fb.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
      phone: ['', [Validators.required, this.validateEuropeanPhone] ],
      pizzaType: ['', Validators.required],
      status: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]]
    });
  }

  ngOnInit() {
    this.pizzaTypes$ = this.orderService.allForSelect();
  }

  onSubmit() {
    if (this.orderForm.valid) {
      const order = this.orderForm.value;
      const customer = {
        name: order.name,
        address: order.address,
        phone: order.phone
      };

      const orderForRequest = {
        customer: customer,
        pizzaType: order.pizzaType,
        status: order.status,
        quantity: order.quantity
      } as OrderForRequest;
      console.log(order);
      console.log(orderForRequest);
      // Do whatever you need to do with the order data here
      this.orderService.createOrder(orderForRequest).subscribe(data=> console.log(data));
      // You can also reset the form after submitting if you want to
      this.orderForm.reset();
    } else {
      // If the form is not valid, mark all fields as touched to show validation errors
      this.orderForm.markAllAsTouched();
    }
  }

  validateEuropeanPhone(control: AbstractControl): ValidationErrors | null {
    const regex = /^(\+|00)(\d{1,3})\s?(\d{6,14})$/;
    const valid = regex.test(control.value);
    return valid ? null : { europeanPhone: true };
  }

}
