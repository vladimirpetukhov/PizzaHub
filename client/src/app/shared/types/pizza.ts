import { OrderPizza } from "./orderPizza";
import { PizzaType } from "./pizzaType";

export interface Pizza {
  id: number;
  pizzaTypeId: number;
  pizzaType: PizzaType;
  orders: OrderPizza[];
}
