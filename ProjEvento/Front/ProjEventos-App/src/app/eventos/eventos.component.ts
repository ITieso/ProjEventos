import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

   eventos: any = [];
   eventosFiltrados: any = [];  //VARIAVEL QUE ARMAZENA O VALOR QUE EU FILTREI
   exibirImagem = true;
   private _filtroLista: string = ''; //VARIAVEL SO PRA ARMAZENA O QUE EU QUERO FILTRAR
   
   
   public get filtroLista() : string{  //ESTE METODO EU RETORNO PARA MEU HTML O EVENTO FILTRADO JA QUE TA ARMAZENADO NO _FILTROlISTA
    return this._filtroLista; 
    //PRIMEIRO EU ATRIBUO O VALOR PARA O SET, E DEPOIS EU USO ESSE GET PRA PEGAR O VALOR DO SET E MANDAR PARA O HTML
   }

   public set filtroLista(value: string){//ESTE METODO EU PEGO O VALOR QUE VEM DO HTML E ATRIBUO PRA VARIAVEL _FILTROLISTA
     this._filtroLista = value;
     this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
     //LINHA 23 EU ATRIBUO PARA MEU EVENTOSFILTRADOS  O RETORNO DO EVENTO QUE VEM DA FUNCAO FILTRAREVENTOS, EU MANDO PRA ELA FILTRAR E PEGO O QUE VEM
   }

   
   constructor(private http: HttpClient) { }
   ngOnInit(): void {
     this.getEventos();
    }

    filtrarEventos(filtrar : string) : any {
      filtrar = filtrar.toLocaleLowerCase();
        return this.eventos.filter(	
            (evento : any)  => evento.tema.toLocaleLowerCase().indexOf(filtrar) !== -1 
            || evento.local.toLocaleLowerCase().indexOf(filtrar) !== -1)
    }
 
    mostrarImagem(){
      this.exibirImagem = !this.exibirImagem 
  }

    getEventos(): void{
     this.http.get('http://localhost:5000/api/Eventos').subscribe(
        response => {
          this.eventos = response;
          this.eventosFiltrados = this.eventos;
          },
          error => console.log(error)
          )}
}
