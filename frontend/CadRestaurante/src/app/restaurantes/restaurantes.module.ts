import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';


import { RestaurantesComponent } from './restaurantes.component';
import { RestauranteService } from './restaurantes.service';

import { MenuModule } from '../menus/menus.module';

import { RestaurantesRouting, RestaurantesRoutingProviders } from './restaurantes.routing';

@NgModule({
     imports: [ RestaurantesRouting, MenuModule, CommonModule],
     declarations: [RestaurantesComponent],
     exports: [],
     providers:[RestauranteService]
})
export class RestaurantesModule { }