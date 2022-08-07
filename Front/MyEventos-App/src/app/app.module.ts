import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { EventoService } from './services/evento.service';
import { DateTimeFormatPipe } from './helpers/DateTImeFormat.pipe';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppComponent } from './app.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NavComponent } from './shared/nav/nav.component';
import { TituloComponent } from './shared/titulo/titulo.component';


@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
    ContatosComponent,
    PerfilComponent,
    DashboardComponent,
    TituloComponent,
    NavComponent,
    DateTimeFormatPipe
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
    }),
    NgxSpinnerModule
  ],
  providers: [
    EventoService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
