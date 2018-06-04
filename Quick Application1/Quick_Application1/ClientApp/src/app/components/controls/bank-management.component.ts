// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

import { Component, OnInit, AfterViewInit, TemplateRef, ViewChild, Input } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { AppTranslationService } from "../../services/app-translation.service";
import { AccountService } from "../../services/account.service";
import { Utilities } from "../../services/utilities";
import { bancos } from '../../models/bancos.model';
import { Permission } from '../../models/permission.model';
import { AddBancosComponent } from "./bank-info.component";
import { EventManager } from '@angular/platform-browser/src/dom/events/event_manager';
import { BancoService } from '../../services/banco.service';


@Component({
    selector: 'bank-management',
    templateUrl: './bank-management.component.html',
    styleUrls: ['./bank-management.component.css']
})
export class BanksManagementComponent implements OnInit, AfterViewInit {
    columns: any[] = [];
    rows: bancos[] = [];
    rowsCache: bancos[] = [];
    editedBank: bancos;
    sourceBank: bancos;
    editingDescription: { name: string };
    loadingIndicator: boolean;




    @ViewChild('indexTemplate')
    indexTemplate: TemplateRef<any>;

    @ViewChild('descripcionTemplate')
    descripcionTemplate: TemplateRef<any>;

    @ViewChild('actionsTemplate')
    actionsTemplate: TemplateRef<any>;

    @ViewChild('bankModal')
    bankModal: ModalDirective;

    @ViewChild('bankEditor')
    bankEditor: AddBancosComponent;

    constructor(private _bancoService: BancoService, private alertService: AlertService, private translationService: AppTranslationService, private accountService: AccountService) {
    }


    ngOnInit() {

        let gT = (key: string) => this.translationService.getTranslation(key);

        this.columns = [
            { prop: "index", name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
            { prop: 'descripcion', name: gT('bank.management.Title'), width: 50, cellTemplate: this.descripcionTemplate }
        ];

        if (this.canManageBanks)
            this.columns.push({ name: '', width: 130, cellTemplate: this.actionsTemplate, resizeable: false, canAutoResize: false, sortable: false, draggable: false });
        this.loadData();
    }


    ngAfterViewInit() {

        this.bankEditor.changesSavedCallback = () => {
           this.addNewBankToList();
            this.bankModal.hide();
        };

        this.bankEditor.changesCancelledCallback = () => {
            this.editedBank = null;
            this.sourceBank = null;
            this.bankModal.hide();
        };
    }


    addNewBankToList() {
        if (this.sourceBank) {
            Object.assign(this.sourceBank, this.editedBank);

            let sourceIndex = this.rowsCache.indexOf(this.sourceBank, 0);
            if (sourceIndex > -1)
                Utilities.moveArrayItem(this.rowsCache, sourceIndex, 0);

            sourceIndex = this.rows.indexOf(this.sourceBank, 0);
            if (sourceIndex > -1)
                Utilities.moveArrayItem(this.rows, sourceIndex, 0);

            this.editedBank = null;
            this.sourceBank = null;
        }
        else {
            let bank = new bancos();
            Object.assign(bank, this.editedBank);
            this.editedBank = null;

            let maxIndex = 0;
            for (let u of this.rowsCache) {
                if ((<any>u).index > maxIndex)
                    maxIndex = (<any>u).index;
            }

            (<any>bank).index = maxIndex + 1;

            this.rowsCache.splice(0, 0, bank);
            this.rows.splice(0, 0, bank);
            this.rows = [...this.rows];
        }
    }


    loadData() {
        this.alertService.startLoadingMessage();
        this.loadingIndicator = true;

        if (this.canViewBanks) {
            this._bancoService.getBancos().subscribe(results => this.onDataLoadSuccessful(results), error => this.onDataLoadFailed(error));
        }
    }


    onDataLoadSuccessful(bancos: bancos[]) {
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        bancos.forEach((user, index, users) => {
            (<any>user).index = index + 1;
        });

        this.rowsCache = [...bancos];
        this.rows = bancos;

        //this.allRoles = roles;
    }


    onDataLoadFailed(error: any) {
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        this.alertService.showStickyMessage("Load Error", `Unable to retrieve users from the server.\r\nErrors: "${Utilities.getHttpResponseMessage(error)}"`,
            MessageSeverity.error, error);
    }


    onSearchChanged(value: string) {
        this.rows = this.rowsCache.filter(r => Utilities.searchArray(value, false, r.descripcion));
    }

    onEditorModalHidden() {
        this.editingDescription = null;
        this.bankEditor.resetForm(true);
    }


    newBank() {
        this.editingDescription = null;
        this.sourceBank = null;
        this.editedBank = this.bankEditor.newBank();
        this.bankModal.show();
    }


    editBank(row: bancos) {
        this.editingDescription = { name: row.descripcion };
        this.sourceBank = row;
        this.editedBank = this.bankEditor.editBank(row);
        this.bankModal.show();
    }


    deleteBank(row: bancos) {
        this.alertService.showDialog('Are you sure you want to delete \"' + row.descripcion + '\"?', DialogType.confirm, () => this.deleteUserHelper(row));
    }


    deleteUserHelper(row: bancos) {

        this.alertService.startLoadingMessage("Deleting...");
        this.loadingIndicator = true;

        //this.accountService.deleteUser(row)
        //    .subscribe(results => {
        //        this.alertService.stopLoadingMessage();
        //        this.loadingIndicator = false;

        //        this.rowsCache = this.rowsCache.filter(item => item !== row)
        //        this.rows = this.rows.filter(item => item !== row)
        //    },
        //    error => {
        //        this.alertService.stopLoadingMessage();
        //        this.loadingIndicator = false;

        //        this.alertService.showStickyMessage("Delete Error", `An error occured whilst deleting the user.\r\nError: "${Utilities.getHttpResponseMessage(error)}"`,
        //            MessageSeverity.error, error);
        //    });
    }





    get canViewBanks() {
        return this.accountService.userHasPermission(Permission.viewBanksPermission)
    }

    get canManageBanks() {
        return this.accountService.userHasPermission(Permission.manageBanksPermission);
    }
}
