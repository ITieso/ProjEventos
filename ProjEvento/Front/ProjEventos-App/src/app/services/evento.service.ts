import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(
  // providedIn: 'root'  "ESSE É UM JEITO DE DEIXAR ESTA CLASSE DISPONIVEL PRA SER IMPORTADA POR QUEM QUISER"
)
export class EventoService {

  baseURL ='http://localhost:5000/api/Eventos';
  
constructor(private http: HttpClient) { }

 public getEventos() : Observable<Evento[]>{
    return this.http.get<Evento[]>(this.baseURL);
  }

 public getEventosByTema(tema: string) : Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseURL}/tema/${tema}`);
  }

 public getEventoById(id: number) : Observable<Evento>{
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }

}
