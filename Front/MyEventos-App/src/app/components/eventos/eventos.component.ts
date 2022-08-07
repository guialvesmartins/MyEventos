import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef, Type } from '@angular/core';
import {
  NgbModal,
  NgbActiveModal,
  NgbModalConfig,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  providers: [NgbModalConfig, NgbModal,NgbActiveModal],
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  public isMenuCollapsed = true;
  public eventosFiltrados: Evento[] = [];
  //Grid
  public largImg = 150;
  public margImg = 2;
  public mostrarImg = true;
  private filtroListado = '';
  //Modal
  public closeResult = '';

  constructor(
    private eventoService: EventoService,
    private _modalService: NgbModal,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.eventosFiltrados = this.filtroLista
      ? this.filtrarEventos(this.filtroLista)
      : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) =>
        evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public exibirOcultar(): void {
    this.mostrarImg = !this.mostrarImg;
  }

  public getEventos(): void {
    this.eventoService.getEvento().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        console.log(error);
        this.spinner.hide();
        this.toastr.error('Erro ao carregar dados da API','Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  public openModal(template: TemplateRef<any>): void {
    this._modalService.open(template);
  }

  public confirm(): void {
    this._modalService.dismissAll();
    this.toastr.success('Evento Deletado com Sucesso','Deletado!!!');
  }

  public decline(): void {
    this._modalService.dismissAll();
  }
}
