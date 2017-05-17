import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RestaurantesComponent } from './restaurantes.component'

const appRoutes: Routes = [
    { path: 'restaurantes', component: RestaurantesComponent }
];

export const RestaurantesRoutingProviders: any[] = [];
export const RestaurantesRouting: ModuleWithProviders =
    RouterModule.forChild(appRoutes);