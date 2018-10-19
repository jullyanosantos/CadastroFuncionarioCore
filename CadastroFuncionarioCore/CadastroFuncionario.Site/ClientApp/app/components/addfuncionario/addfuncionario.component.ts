import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { GridFuncionarioComponent } from '../gridfuncionario/gridfuncionario.component';
import { FuncionarioService } from '../../services/funcionario.service';

@Component({
    selector: 'createfuncionario',
    templateUrl: './addfuncionario.component.html'
})

export class createfuncionario implements OnInit {

    funcionarioForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any; 

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _funcionarioService: FuncionarioService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.funcionarioForm = this._fb.group({
            id: 0,
            nome: ['', [Validators.required]],
            nascimento: ['', [Validators.required]],
            salario: ['', []],
            ativo: ['', [Validators.required]],
        })
    }

    ngOnInit() {

        if (this.id > 0) {
            this.title = "Edit";
            debugger
            this._funcionarioService.getFuncionarioById(this.id)
                .subscribe(resp => this.funcionarioForm.setValue(resp)
                    , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.funcionarioForm.valid) {
            return;
        }

        //alert(this.title);
        if (this.title == "Create") {
            this._funcionarioService.saveFuncionario(this.funcionarioForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/exibir-funcionarios']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._funcionarioService.updateFuncionario(this.funcionarioForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/exibir-funcionarios']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/exibir-funcionarios']);
    }

    get nome() { return this.funcionarioForm.get('nome'); }
    get nascimento() { return this.funcionarioForm.get('nascimento'); }
    get ativo() { return this.funcionarioForm.get('ativo'); }
    get salario() { return this.funcionarioForm.get('salario'); }
}