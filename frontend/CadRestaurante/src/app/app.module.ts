import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {CommonModule} from '@angular/common';

import { AppRouting, AppRoutingProviders } from './app.routing';
import { AppComponent } from './app.component';
import { HomePageComponent } from './home/home-page.component';

import { MenuModule } from './menus/menus.module';
import { RestaurantesModule } from './restaurantes/restaurantes.module';
import { PratosModule } from './pratos/pratos.module';


@NgModule({
  declarations: [
    AppComponent, HomePageComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    HttpModule,
    AppRouting,
    MenuModule,
    RestaurantesModule,
    PratosModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
