import { PizzaType } from './pizzaType'
import { Customer } from "./customer";
import { OrderPizza } from "./orderPizza";

export interface Order {
  id: number;
  quantity: number;
  customerId: number;
  status: string;
  customer: Customer;
  pizzas: OrderPizza[];
}

export interface OrderForRequest {
  pizzaType: number;
  quantity: number;
  status: string;
  customer: Customer;
  pizzas: OrderPizza[];
}

export interface OrderForResponse {
  id: number;
  orderCode: string;
  quantity: number;
  status: string;
  customer: Customer;
  pizza: PizzaType
}

export interface OrderForUpdateRequest {
  quantity: number;
  status: string;
}

export interface OrderForDashboardResponse {
  orders: OrderForResponse[];
  totalPages: number;
  page: number;
}
