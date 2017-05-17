import { Component, OnInit } from '@angular/core';
import { RestauranteService } from './restaurantes.service';

@Component({
    selector: 'restaurante-list',
    templateUrl: './restaurantes.component.html'
})
export class RestaurantesComponent implements OnInit {

    public restaurantes: any[];

    constructor(private service: RestauranteService) { }

    ngOnInit() {
        this.service.obterTodos().subscribe(result => {
            this.restaurantes = result;
        })
    }

    excluir(id){
        alert(id);
    }

    editar(id){
        alert(id);
    }
}