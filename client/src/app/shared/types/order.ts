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
