import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { MenuSuperiorComponent } from './menu-superior.component';

import { FooterComponent } from './footer.component';

@NgModule({
    imports: [RouterModule],
    declarations: [MenuSuperiorComponent, FooterComponent],
    exports: [MenuSuperiorComponent, FooterComponent]
})

export class MenuModule { }