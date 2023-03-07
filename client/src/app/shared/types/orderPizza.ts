import { Order } from "./order";
import { Pizza } from "./pizza";

export interface OrderPizza {
  id: number;
  orderId: number;
  pizzaId: number;
  quantity: number;
  order: Order;
  pizza: Pizza;
}
