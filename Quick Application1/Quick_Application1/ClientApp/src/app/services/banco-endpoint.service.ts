import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/catch';

import { AuthService } from './auth.service';
import { EndpointFactory } from './endpoint-factory.service';
import { ConfigurationService } from './configuration.service';


@Injectable()
export class BancoEndpont extends EndpointFactory {

    private readonly _bancos: string = "/api/banco/bancos";
    private readonly _bancoId: string = "/api/banco/";
    private readonly _guardarBanco: string = "/api/banco/";
    private readonly _actualizarBanco: string = "/api/banco/actualizar/";
    private readonly _borrarBanco: string = "/api/banco/borrar/";


    get bancosUrl() { return this.configurations.baseUrl + this._bancos; }
    get bancosIdUrl() { return this.configurations.baseUrl + this._bancoId; }
    get guardarBancoUrl() { return this.configurations.baseUrl + this._guardarBanco; }
    get actualizarBancoUrl() { return this.configurations.baseUrl + this._actualizarBanco; }
    get borrarBancoUrl() { return this.configurations.baseUrl + this._borrarBanco; }

    constructor(http: HttpClient, configurations: ConfigurationService, injector: Injector) {
        super(http, configurations, injector);
    }


    getBancosEndpoint<T>(): Observable<T> {
        let endpointUrl = `${this.bancosUrl}/`;
        
        return this.http.get<T>(endpointUrl, this.getRequestHeaders())
            .catch(error => {
                return this.handleError(error, () => this.getBancosEndpoint());
            });
    }

    getBancoIdEndpoint<T>(bancoId?: number): Observable<T> {
        let endpointUrl = `${this.bancosIdUrl}/${bancoId}`;

        return this.http.get<T>(endpointUrl, this.getRequestHeaders())
            .catch(error => {
               return this.handleError(error, () => this.getBancoIdEndpoint(bancoId));
           });
    }

    getGuardarBancoEndpoint<T>(bancoObject: any): Observable<T> {
        let endpointUrl = `${this.guardarBancoUrl}/`;

        return this.http.post<T>(endpointUrl, JSON.stringify(bancoObject), this.getRequestHeaders())
            .catch(error => {
                return this.handleError(error, () => this.getGuardarBancoEndpoint(bancoObject));
            });
    }

    getActualizarBancoEndpoint<T>(bancoObject: any, bancoId?: number): Observable<T> {
        let endpointUrl = `${this.actualizarBancoUrl}/${bancoId}`;

        return this.http.put<T>(endpointUrl, JSON.stringify(bancoObject), this.getRequestHeaders())
            .catch(error => {
               return this.handleError(error, () => this.getActualizarBancoEndpoint(bancoObject));
            });
    }

    getEliminarBancoEndpoint<T>(bancoObject: any, bancoId?: number): Observable<T> {
        let endpointUrl = `${this.borrarBancoUrl}/${bancoId}`;

        return this.http.put<T>(endpointUrl, JSON.stringify(bancoObject), this.getRequestHeaders())
            .catch(error => {
               return this.handleError(error, () => this.getActualizarBancoEndpoint(bancoObject));
            });
    }



}
