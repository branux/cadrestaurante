import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomePageComponent } from './home/home-page.component'

const appRoutes: Routes = [
    { path: '', component: HomePageComponent },
    { path: '**', redirectTo: '', pathMatch: 'full' },

];

export const AppRoutingProviders: any[] = [];
export const AppRouting: ModuleWithProviders =
    RouterModule.forRoot(appRoutes);