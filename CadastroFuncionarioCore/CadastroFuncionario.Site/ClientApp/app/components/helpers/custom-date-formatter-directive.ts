import { Directive, HostListener, ElementRef, OnInit } from "@angular/core";
import { CustomDateFormatterPipe } from "./custom-date-formatter-pipe";

@Directive({ selector: "[customDateFormatterDirective]" })
export class CustomDateFormatterDirective implements OnInit {

    private el: any;

    constructor(
        private elementRef: ElementRef,
        private datePipe: CustomDateFormatterPipe
    ) {
        this.el = this.elementRef.nativeElement;
    }

    ngOnInit() {
        
        this.el.value = this.datePipe.transform(this.el.value);
    }

    //@HostListener("focus", ["$event.target.value"])
    //onFocus(value) {
    //    this.el.value = this.datePipe.parse(value); // opossite of transform
    //}

    @HostListener("blur", ["$event.target.value"])
    onBlur(value) {

        if (/^(\d{1,2}\d{1,2}\d{4})$/.test(value)) {

            this.el.value =  this.el.value.replace(/(\d{2})(\d{2})(\d{4})/g, "\$1/\$2/\$3");
        }     
        //this.el.value = this.datePipe.transform(value);
    }
}