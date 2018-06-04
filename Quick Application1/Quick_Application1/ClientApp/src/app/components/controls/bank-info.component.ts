import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BancoService } from '../../services/banco.service';
import { Route } from '@angular/router/src/config';
import { bancos } from '../../models/bancos.model'
import { Utilities } from '../../services/utilities';
import { AccountService } from "../../services/account.service";
import { Permission } from '../../models/permission.model';


@Component({
    selector: 'add-bancos',
    templateUrl: './bank-info.component.html'
})

export class AddBancosComponent implements OnInit{
    
    title: string = "Crear";
    id: number;
    errorMessage: any;

    private isEditMode = false;
    private isNewBank = false;
    private isSaving = false;
    //private isChangePassword = false;
    private isEditingBank = false;
    private showValidationErrors = false;
    private editingDescription: string;
    private uniqueId: string = Utilities.uniqueId();
    private bank: bancos = new bancos();
    private bankEdit: bancos;

    public formResetToggle = true;

    public changesSavedCallback: () => void;
    public changesFailedCallback: () => void;
    public changesCancelledCallback: () => void;

    @Input()
    isViewOnly: boolean;

    @Input()
    isGeneralEditor = false;

    @ViewChild('f')
    private bancoForm;

    //ViewChilds Required because ngIf hides template variables from global scope
    @ViewChild('descripcion')
    private descripcion;


    constructor(private _bancoService: BancoService, private alertService: AlertService, private accountService: AccountService ) {
        if (!this.isGeneralEditor) {
            this.loadCurrentUserData();
        }
    }

    ngOnInit() {
        if (!this.isGeneralEditor) {
            this.loadCurrentUserData();
        }
    }

    private loadCurrentUserData() {
        this.alertService.startLoadingMessage();
        if (this.canViewAllBanks) {
            this._bancoService.getBancoById().subscribe(results => this.onCurrentUserDataLoadSuccessful(results[0]), error => this.onCurrentUserDataLoadFailed(error));
        }
    }

    private onCurrentUserDataLoadSuccessful(banco: bancos) {
        this.alertService.stopLoadingMessage();
        this.bank = banco;
    }

    private onCurrentUserDataLoadFailed(error: any) {
        this.alertService.stopLoadingMessage();
        this.alertService.showStickyMessage("Load Error", `Unable to retrieve user data from the server.\r\nErrors: "${Utilities.getHttpResponseMessage(error)}"`,
            MessageSeverity.error, error);

        this.bank = new bancos();
    }

    private saveSuccessHelper(banco?: bancos) {
        //this.testIsRoleUserCountChanged(this.bank, this.bankEdit);

        if (banco)
            Object.assign(this.bankEdit, banco);

        this.isSaving = false;
        this.alertService.stopLoadingMessage();
        this.showValidationErrors = false;

        Object.assign(this.bank, this.bankEdit);
        this.bankEdit = new bancos();
        this.resetForm();


        if (this.isGeneralEditor) {
            if (this.isNewBank)
                this.alertService.showMessage("Éxito", `El banco \"${this.bank.descripcion}\" fué creado exitósamente`, MessageSeverity.success);
            else if (!this.isEditingBank)
                this.alertService.showMessage("Éxito", `Los cambios a el banco \"${this.bank.descripcion}\" fueron exitosos`, MessageSeverity.success);
        }


        this.isEditMode = false;


        if (this.changesSavedCallback)
            this.changesSavedCallback();
    }

    newBank() {
        this.isGeneralEditor = true;
        this.isNewBank = true;

        //this.allRoles = [...allRoles];
        this.editingDescription = null;
        this.bank = this.bankEdit = new bancos();
        this.bankEdit.deleted = false;
        this.edit();

        return this.bankEdit;
    }

    editBank(bank: bancos) {
        if (bank) {
            this.isGeneralEditor = true;
            this.isNewBank = false;


            this.editingDescription = bank.descripcion;
            this.bank = new bancos();
            this.bankEdit = new bancos();
            Object.assign(this.bank, bank);
            Object.assign(this.bankEdit, bank);
            this.edit();

            return this.bankEdit;
        }
        else {
           // return this.newUser(allRoles);
            return null;
        }
    }

    private edit() {
        if (!this.isGeneralEditor) {
            //this.isEditingSelf = true;
            this.bankEdit = new bancos();
            Object.assign(this.bankEdit, this.bank);
        }
        else {
            if (!this.bankEdit)
                this.bankEdit = new bancos();

            //this.isEditingSelf = this.accountService.currentUser ? this.userEdit.id == this.accountService.currentUser.id : false;
        }

        this.isEditMode = true;
        this.showValidationErrors = true;
    }

    //private edit() {
    //    if (!this.isGeneralEditor) {
    //        this.isEditingSelf = true;
    //        this.userEdit = new UserEdit();
    //        Object.assign(this.userEdit, this.user);
    //    }
    //    else {
    //        if (!this.userEdit)
    //            this.userEdit = new UserEdit();

    //        this.isEditingSelf = this.accountService.currentUser ? this.userEdit.id == this.accountService.currentUser.id : false;
    //    }

    //    this.isEditMode = true;
    //    this.showValidationErrors = true;
    //    this.isChangePassword = false;
    //}


    //private save() {
    //    this.isSaving = true;
    //    this.alertService.startLoadingMessage("Saving changes...");

    //    if (this.isNewUser) {
    //        this.accountService.newUser(this.userEdit).subscribe(user => this.saveSuccessHelper(user), error => this.saveFailedHelper(error));
    //    }
    //    else {
    //        this.accountService.updateUser(this.userEdit).subscribe(response => this.saveSuccessHelper(), error => this.saveFailedHelper(error));
    //    }
    //}

    private close() {
        this.bankEdit = this.bank = new bancos();
        this.showValidationErrors = false;
        this.resetForm();
        this.isEditMode = false;

        if (this.changesSavedCallback)
            this.changesSavedCallback();
    }

    resetForm(replace = false) {

        if (!replace) {
            this.bancoForm.reset();
        }
        else {
            this.formResetToggle = false;

            setTimeout(() => {
                this.formResetToggle = true;
            });
        }
    }

    get canViewAllBanks() {
        return this.accountService.userHasPermission(Permission.viewBanksPermission);
    }


}
