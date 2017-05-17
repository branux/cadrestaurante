import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PratosComponent } from './pratos.component'

const appRoutes: Routes = [
    { path: 'pratos', component: PratosComponent }
];

export const PratosRoutingProviders: any[] = [];
export const PratosRouting: ModuleWithProviders =
    RouterModule.forChild(appRoutes);