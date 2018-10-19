﻿import { Directive, HostListener, ElementRef, OnInit } from "@angular/core";
import { CustomCurrencyPipe } from "./custom-currency-pipe";

@Directive({ selector: "[customCurrencyFormatterDirective]" })
export class CustomCurrencyFormatterDirective implements OnInit {

    private el: any;

    constructor(
        private elementRef: ElementRef,
        private currencyPipe: CustomCurrencyPipe
    ) {
        this.el = this.elementRef.nativeElement;
    }

    ngOnInit() {
        this.el.value = this.currencyPipe.transform(this.el.value);
    }

    @HostListener("focus", ["$event.target.value"])
    onFocus(value) {
        if (this.el.value)
            this.el.value = this.currencyPipe.parse(value); // opossite of transform
    }

    @HostListener("blur", ["$event.target.value"])
    onBlur(value) {
        if (this.el.value)
            this.el.value = this.currencyPipe.transform(value);
    }
}