import { FormsModule } from '@angular/forms'
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PizzasComponent } from './pizzas.component';
import { PizzasService } from './pizzas.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [PizzasComponent],
  providers: [ PizzasService ]
})
export class PizzasModule { }
