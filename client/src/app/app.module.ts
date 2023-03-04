import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { environment } from 'src/environments/environment';
import { CoreModule } from './core/core.module';
import { PizzasModule } from './pizzas/pizzas.module';
import { FormsModule } from '@angular/forms';

export const API_URL = environment.apiUrl;

const MODULES = [
  SharedModule,
  CoreModule,
  PizzasModule,
  BrowserModule,
  AppRoutingModule,
  FormsModule
]

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: MODULES,
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
