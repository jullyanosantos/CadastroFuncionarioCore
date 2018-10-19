import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { DatePipe } from '@angular/common';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { FilterPipe } from './components/gridfuncionario/filter.pipe';
import { CustomCurrencyFormatterDirective } from './components/helpers/currency-formatter-directive';
import { CustomCurrencyPipe } from './components/helpers/custom-currency-pipe';

import { CustomDateFormatterPipe } from './components/helpers/custom-date-formatter-pipe';
import { CustomDateFormatterDirective } from './components/helpers/custom-date-formatter-directive';

import { GridFuncionarioComponent } from './components/gridfuncionario/gridfuncionario.component';
import { createfuncionario } from './components/addFuncionario/Addfuncionario.component'
import { FuncionarioService } from './services/funcionario.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        GridFuncionarioComponent,
        createfuncionario,
        FilterPipe,
        CustomCurrencyPipe,
        CustomCurrencyFormatterDirective,
        CustomDateFormatterPipe,
        CustomDateFormatterDirective
    ],

    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule, //tive q add pra funcionar
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'exibir-funcionarios', component: GridFuncionarioComponent },
            { path: 'criar-funcionario', component: createfuncionario },
            { path: 'funcionario/editar/:id', component: createfuncionario },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        FuncionarioService,
        CustomCurrencyPipe,
        CustomDateFormatterPipe,
        DatePipe
    ],
    exports: [
        FilterPipe,
        CustomCurrencyFormatterDirective,
        CustomCurrencyPipe,
        CustomDateFormatterPipe,
        CustomDateFormatterDirective
    ],
})
export class AppModuleShared {
}