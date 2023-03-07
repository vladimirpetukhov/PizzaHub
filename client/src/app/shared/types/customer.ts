import { Order } from "./order";

export interface Customer {
  id: number;
  name: string;
  address: string;
  phone: string;
  orders: Order[];
}

export interface CustomerForResponse {
  customers: Customer[];
};

export type CustomerForRequest = {
  name: string;
  address: string;
  phone: string;
}
