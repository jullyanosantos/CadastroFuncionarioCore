import { Component, Inject, Pipe, PipeTransform} from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { FuncionarioService } from '../../services/funcionario.service'

@Component({
    selector: 'gridfuncionario',
    templateUrl: './gridfuncionario.component.html'
})

export class GridFuncionarioComponent {
    public lstFuncionario: FuncionarioData[];
    public searchString: string;

    constructor(public http: Http, private _router: Router, private _funcionarioService: FuncionarioService) {

        this.getFuncionarios();
    }

    getFuncionarios() {
        this._funcionarioService.getFuncionarios().subscribe(
            data => this.lstFuncionario = data            
        )
    }

    delete(funcionarioID) {
        var confirm = window.confirm("Deseja excluir o funcionário: " + funcionarioID);
        if (confirm) {
            this._funcionarioService.deleteFuncionario(funcionarioID).subscribe((data) => {
                this.getFuncionarios();
            }, error => console.error(error))
        }
    } 
}

interface FuncionarioData {
    id: number;
    nome: string;
    nascimento: string;
    salario: string;
    ativo: number;
}