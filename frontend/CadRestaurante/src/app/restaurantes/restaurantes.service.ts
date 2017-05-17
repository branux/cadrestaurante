import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';

@Injectable()
export class RestauranteService {
    constructor(private http: Http) { }

    obterTodos() {
        return this.http
            .get(environment.serviceUrl + 'v1/restaurantes')
            .map((res: Response) => res.json().data);
    }
}