
export interface Pizza {
  id: number;
  name: string;
  price: number;
  description: string;
}

export type PizzasResponse = {
  pizzas: Pizza[];
  totalPages: number;
  page: number;
};

export type PizzaForRequest = {
  name: string;
  price: number;
  description: string;
};

export type PizzaTypeSelect = {
  id: number;
  name: string;
};

