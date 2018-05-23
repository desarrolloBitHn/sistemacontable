import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { BancoEndpont } from './banco-endpoint.service';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { bancos } from '../models/bancos.model';


@Injectable()
export class BancoService {

    constructor(private router: Router, private http: HttpClient, private bancoEndpoint: BancoEndpont) {
        
    }
    getBancos() {

        return this.bancoEndpoint.getBancosEndpoint<bancos[]>();
    }
}
