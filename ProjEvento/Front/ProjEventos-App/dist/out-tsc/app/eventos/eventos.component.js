import { __decorate } from "tslib";
import { Component } from '@angular/core';
let EventosComponent = class EventosComponent {
    constructor(http) {
        this.http = http;
        this.eventos = [];
        this.eventosFiltrados = []; //VARIAVEL QUE ARMAZENA O VALOR QUE EU FILTREI
        this.exibirImagem = true;
        this._filtroLista = ''; //VARIAVEL SO PRA ARMAZENA O QUE EU QUERO FILTRAR
    }
    get filtroLista() {
        return this._filtroLista;
        //PRIMEIRO EU ATRIBUO O VALOR PARA O SET, E DEPOIS EU USO ESSE GET PRA PEGAR O VALOR DO SET E MANDAR PARA O HTML
    }
    set filtroLista(value) {
        this._filtroLista = value;
        this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
        //LINHA 23 EU ATRIBUO PARA MEU EVENTOSFILTRADOS  O RETORNO DO EVENTO QUE VEM DA FUNCAO FILTRAREVENTOS, EU MANDO PRA ELA FILTRAR E PEGO O QUE VEM
    }
    ngOnInit() {
        this.getEventos();
    }
    filtrarEventos(filtrar) {
        filtrar = filtrar.toLocaleLowerCase();
        return this.eventos.filter((evento) => evento.tema.toLocaleLowerCase().indexOf(filtrar) !== -1
            || evento.local.toLocaleLowerCase().indexOf(filtrar) !== -1);
    }
    mostrarImagem() {
        this.exibirImagem = !this.exibirImagem;
    }
    getEventos() {
        this.http.get('http://localhost:5000/api/Eventos').subscribe(response => {
            this.eventos = response;
            this.eventosFiltrados = this.eventos;
        }, error => console.log(error));
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