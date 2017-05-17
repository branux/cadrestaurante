import { NgModule } from '@angular/core';

import { RestaurantesComponent } from './restaurantes.component';

import { MenuModule } from '../menus/menus.module';

import { RestaurantesRouting, RestaurantesRoutingProviders } from './restaurantes.routing';

@NgModule({
     imports: [ RestaurantesRouting, MenuModule],
     declarations: [RestaurantesComponent],
     exports: []
})
export class RestaurantesModule { }