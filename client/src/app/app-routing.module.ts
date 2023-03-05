import { OrdersComponent } from './orders/orders.component'
import { PizzasComponent } from './pizzas/pizzas.component'
import { AppComponent } from './app.component'
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PizzasModule } from './pizzas/pizzas.module';

const routes: Routes = [

  { path: 'pizza', component: PizzasComponent  },
  { path: 'order', component: OrdersComponent  },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
