import { Component, OnInit } from '@angular/core';
import { Pizza, PizzaForRequest } from './pizza';
import { PizzasService } from './pizzas.service';

@Component({
  selector: 'app-pizzas',
  templateUrl: './pizzas.component.html',
  styleUrls: ['./pizzas.component.css']
})
export class PizzasComponent implements OnInit {

  pizzas: Pizza[] = [];
  pizza: PizzaForRequest = {
    name: '',
    price: 0,
    description: ''
  };

  newPizza: Pizza = {
    id: 0,
    name: '',
    price: 0,
    description: ''
  };

  page: number = 1;
  totalPages: number = 1;

  isNewRowVisible = false;
  editedIndex = -1;
  isEditing = false;

  constructor(private pizzaService: PizzasService) { }

  ngOnInit() {
    this.loadPizzas();
  }

  loadPizzas() {
    this.pizzaService.all(this.page).subscribe(response => {
      this.pizzas = response.pizzas;
      this.totalPages = response.totalPages;
      this.page = response.page;
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

  saveEdit(index: number, pizza: Pizza) {
    this.pizzas[index] = pizza;
    this.editedIndex = -1;
  }

  saveNewPizza() {
    this.pizzaService.create(this.newPizza).subscribe(() => {
      this.loadPizzas();
    }, error => {
      console.log(error);
    });
    this.newPizza = { id: 0, name: '', price: 0, description: '' };
    this.isNewRowVisible = false;
  }

  cancelNewPizza() {
    this.isNewRowVisible = false;
    this.newPizza = { id: 0, name: '', price: 0, description: '' };
  }

  nextPage() {
    if (this.page < this.totalPages) {
      this.page++;
      this.loadPizzas();
    }
  }

  previousPage() {
    if (this.page > 1) {
      this.page--;
      this.loadPizzas();
    }
  }

  goToPage(pageNumber: number) {
    if (pageNumber >= 1 && pageNumber <= this.totalPages) {
      this.page = pageNumber;
      this.loadPizzas();
    }
  }

}
