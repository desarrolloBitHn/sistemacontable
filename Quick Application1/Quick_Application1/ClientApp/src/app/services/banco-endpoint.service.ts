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

    get bancosUrl() { return this.configurations.baseUrl + this._bancos; }

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


    //getBancos() {
    //    return this._http.get( "http://localhost:56689/api/bancos")
    //        .map((response: Response) => response.json())
    //        .catch(this.errorHandler);
    //}
    //getBancoById(id: number) {
    //    return this._http.get("http://localhost:56689/api/bancos/" + id)
    //        .map((response: Response) => response.json())
    //        .catch(this.errorHandler)
    //}
    //saveBancos(banco) {
    //    return this._http.post('http://localhost:56689/api/bancos/', banco)
    //        .map((response: Response) => response.json())
    //        .catch(this.errorHandler)
    //}
    //updateBanco(id, banco) {
    //    return this._http.put('http://localhost:56689/api/bancos/' + id, banco )
    //        .map((response: Response) => response.json())
    //        .catch(this.errorHandler);
    //}
    ////deleteEmployee(id) {
    ////    return this._http.delete("http://localhost:56689/api/bancos/Delete/" + id)
    ////        .map((response: Response) => response.json())
    ////        .catch(this.errorHandler);
    ////}
    //errorHandler(error: Response) {
    //    console.log(error);
    //    return Observable.throw(error);
    //}
}
