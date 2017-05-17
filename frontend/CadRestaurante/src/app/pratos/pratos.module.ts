import { NgModule } from '@angular/core';

import { PratosComponent } from './pratos.component';

import { MenuModule } from '../menus/menus.module';

import { PratosRouting, PratosRoutingProviders } from './pratos.routing';

@NgModule({
     imports: [ PratosRouting, MenuModule],
     declarations: [PratosComponent],
     exports: [PratosComponent]
})
export class PratosModule { }