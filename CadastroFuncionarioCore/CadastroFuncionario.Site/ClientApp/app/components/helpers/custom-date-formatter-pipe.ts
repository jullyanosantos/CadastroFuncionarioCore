import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
    name: 'customDateFormatterPipe',
})

export class CustomDateFormatterPipe implements PipeTransform {
    transform(value: string | null) {
        var datePipe = new DatePipe("pt-BR");

        debugger
        value = datePipe.transform(value, 'dd-MM-yyyy');
        return value;
    }
}