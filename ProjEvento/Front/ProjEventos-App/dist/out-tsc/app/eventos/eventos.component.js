import { __decorate } from "tslib";
import { Component } from '@angular/core';
let EventosComponent = class EventosComponent {
    constructor(http) {
        this.http = http;
    }
    ngOnInit() {
        this.getEventos();
    }
    getEventos() {
        this.http.get('http://localhost:5000/api/Eventos').subscribe(response => this.eventos = response, error => console.log(error));
    }
};
EventosComponent = __decorate([
    Component({
        selector: 'app-eventos',
        templateUrl: './eventos.component.html',
        styleUrls: ['./eventos.component.css']
    })
], EventosComponent);
export { EventosComponent };
//# sourceMappingURL=eventos.component.js.map