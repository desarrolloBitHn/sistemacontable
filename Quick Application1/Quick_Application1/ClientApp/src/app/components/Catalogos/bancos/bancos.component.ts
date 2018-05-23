import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { BancoService } from '../../../services/banco.service'; 
import { bancos } from '../../../models/bancos.model'


@Component({
    selector: 'bancos',
    templateUrl: './bancos.component.html'
})  

export class BancosComponent {
    public bancosList: bancos[];
    public banco: bancos;
    public bancosList0: bancos[];
    constructor( private _bancoService: BancoService) {
        this.getBancos();
    }
    getBancos() {
        this._bancoService.getBancos().subscribe(
            data => this.bancosList = data
        );

    }
    
    //delete(bancoID) {
    //    var ans = confirm("Quieres eliminar el banco con el Id: " + bancoID);
    //    if (ans) {
    //        this._bancoService.getBancoById(bancoID)
    //            .subscribe((resp) => {
    //                this.banco = resp;
    //                this.banco.deleted = true;
    //                this._bancoService.updateBanco(bancoID, this.banco).subscribe((data) => {
    //                    this.getBancos();
    //                }, error => console.error(error));
    //            }, error => console.error(error));
    //    }
    //}
}  
