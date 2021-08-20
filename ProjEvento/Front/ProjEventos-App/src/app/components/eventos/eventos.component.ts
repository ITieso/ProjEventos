import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';



@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css'],
  
 // providers: [EventoService] //ASSIM EU ESTOU INJETANDO A MINHA CLASSE SERVICE 
})
export class EventosComponent implements OnInit {
  modalRef = {} as BsModalRef;
   eventos: Evento[] = [];
   eventosFiltrados: Evento[] = [];  //VARIAVEL QUE ARMAZENA O VALOR QUE EU FILTREI
   exibirImagem = true;
   private _filtroLista = ''; //VARIAVEL SO PRA ARMAZENA O QUE EU QUERO FILTRAR

   public get filtroLista() : string{  //ESTE METODO EU RETORNO PARA MEU HTML O EVENTO FILTRADO JA QUE TA ARMAZENADO NO _FILTROlISTA
   return this._filtroLista; 
    //PRIMEIRO EU ATRIBUO O VALOR PARA O SET, E DEPOIS EU USO ESSE GET PRA PEGAR O VALOR DO SET E MANDAR PARA O HTML
   }

   public set filtroLista(value: string){//ESTE METODO EU PEGO O VALOR QUE VEM DO HTML E ATRIBUO PRA VARIAVEL _FILTROLISTA
     this._filtroLista = value;
     this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
     //LINHA 23 EU ATRIBUO PARA MEU EVENTOSFILTRADOS  O RETORNO DO EVENTO QUE VEM DA FUNCAO FILTRAREVENTOS, EU MANDO PRA ELA FILTRAR E PEGO O QUE VEM
   }

   
  constructor(
   private _eventoService: EventoService, 
   private _modalService: BsModalService,
   private _toastr: ToastrService,
   private _spinner: NgxSpinnerService
   ) { }


  ngOnInit(): void {
     this.getEventos();
     this._spinner.show();
    }

  public filtrarEventos(filtrar : string) : Evento[] {
    filtrar = filtrar.toLocaleLowerCase();
     return this.eventos.filter(	
      (evento : Evento)  => evento.tema.toLocaleLowerCase().indexOf(filtrar) !== -1 
        || evento.local.toLocaleLowerCase().indexOf(filtrar) !== -1)
    }
 
    public mostrarImagem(){
      this.exibirImagem = !this.exibirImagem 
  }

    public getEventos() {
    const observer = {
      next:(_eventosResp : Evento[]) => {
        this.eventos = _eventosResp;
        this.eventosFiltrados = this.eventos;
        },

        error:(error : any) => {
          this._spinner.hide();
          this._toastr.error("Erro ao carregar os eventos", "Error");
        },
         complete:() => {
            this._spinner.hide();
          } 
      }
      this._eventoService.getEventos().subscribe(observer
    
        // (_eventosResp : Evento[]) => {
        //   this.eventos = _eventosResp;
        //   this.eventosFiltrados = this.eventos;
        //  },
        //   error => console.log(error)
         )}

 
 openModal(template: TemplateRef<any>) {
  this.modalRef = this._modalService.show(template, {class: 'modal-sm'});
 }
       
 confirm(): void {       
   this.modalRef.hide();
   this._toastr.success('Evento foi deletado', 'Deletado');
  }
 
       
 decline(): void {     
   this.modalRef.hide();
   this._toastr.success('Hello world!', 'Toastr fun!');
  
 }
}
