import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class FuncionarioService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = "http://localhost:60904/"; //baseUrl;
    }

    getFuncionarios() {
        return this._http.get(this.myAppUrl + 'api/funcionario/list-all')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getFuncionarioById(id: number) {
        return this._http.get(this.myAppUrl + "api/funcionario/get-func/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveFuncionario(funcionario) {
        return this._http.post(this.myAppUrl + 'api/funcionario/save-func', funcionario)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateFuncionario(funcionario) {
        return this._http.put(this.myAppUrl + 'api/funcionario/update-func', funcionario)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteFuncionario(id) {
        return this._http.delete(this.myAppUrl + "api/funcionario/delete-func/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}