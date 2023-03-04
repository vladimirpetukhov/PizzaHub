import { CardNavComponent } from './card-nav/card-nav.component'
import { BrowserModule } from '@angular/platform-browser'
import { RouterModule } from '@angular/router'
import { NgModule } from '@angular/core';

@NgModule({
  imports: [
    RouterModule,
    BrowserModule
  ],
  declarations: [ CardNavComponent],
  exports: [ CardNavComponent ]
})
export class SharedModule { }
