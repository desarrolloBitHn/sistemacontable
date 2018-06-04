import { Component, Inject, OnInit, OnDestroy, ViewChild} from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';

import { fadeInOut } from '../../services/animations';
import 'rxjs/add/operator/switchMap';
import { BootstrapTabDirective } from "../../directives/bootstrap-tab.directive";

import { AccountService } from "../../services/account.service";
import { BancoService } from '../../services/banco.service'; 
import { bancos } from '../../models/bancos.model';
import { Permission } from '../../models/permission.model';


@Component({
    selector: 'catalogos',
    templateUrl: './catalogos.component.html',
    animations: [fadeInOut]
})  

export class CatalogosComponent implements OnInit, OnDestroy{
    isCatalogueActivated = true;
    isAccountActivated = false;


    fragmentSubscription: any;

    readonly bankTab = "bank";
    readonly accountTab = "account";

    public bancosList: bancos[];
    public banco: bancos;
    public bancosList0: bancos[];

    @ViewChild("tab")
    tab: BootstrapTabDirective;

    constructor(private route: ActivatedRoute, private _bancoService: BancoService, private _accountService: AccountService) {
        this.getBancos();
    }

    ngOnInit() {
        this.fragmentSubscription = this.route.fragment.subscribe(anchor => this.showContent(anchor));
    }


    ngOnDestroy() {
        this.fragmentSubscription.unsubscribe();
    }

    getBancos() {
        this._bancoService.getBancos().subscribe(
            data => this.bancosList = data
        );

    }

    onShowTab(event) {
        let activeTab = event.target.hash.split("#", 2).pop();

        this.isCatalogueActivated = activeTab == this.bankTab;
        this.isAccountActivated = activeTab == this.accountTab;
    }

    showContent(anchor: string) {
        if ((this.isFragmentEquals(anchor, this.bankTab) && !this.canViewBanks)
            // ||(this.isFragmentEquals(anchor, this.accountTab) && !this.canViewRoles)
        )
        {
            return;
        }
        this.tab.show(`#${anchor || this.bankTab}Tab`);
    }

    isFragmentEquals(fragment1: string, fragment2: string) {

        if (fragment1 == null)
            fragment1 = "";

        if (fragment2 == null)
            fragment2 = "";

        return fragment1.toLowerCase() == fragment2.toLowerCase();
    }

    get canViewBanks() {
        return this._accountService.userHasPermission(Permission.viewBanksPermission);
    }

    //get canViewAccount() {
    //    return this._accountService.userHasPermission(Permission.viewAccountPermission);
    //}


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
