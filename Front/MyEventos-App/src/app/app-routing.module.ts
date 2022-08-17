import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './components/eventos/evento-lista/evento-lista.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { UserComponent } from './components/user/user.component';
import { RegistrarionComponent } from './components/user/registrarion/registrarion.component';
import { LoginComponent } from './components/user/login/login.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';

const routes: Routes = [
  {
    path: 'user', component: UserComponent,
    children:[
      { path: 'login', component: LoginComponent},
      { path: 'registration', component: RegistrarionComponent}
    ]
  },
  { path: 'user/perfil'      , component: PerfilComponent },
  { path: 'eventos', redirectTo: 'eventos/lista'},
  {
    path: 'eventos'     , component: EventosComponent,
    children:[
      { path: 'detalhe/:id' , component: EventoDetalheComponent    },
      { path: 'detalhe'     , component: EventoDetalheComponent },
      { path: 'lista'       , component: EventoListaComponent  },
    ]
  },
  { path: 'contatos'    , component: ContatosComponent },
  { path: 'palestrantes', component: PalestrantesComponent },
  { path: 'dashBoard'   , component: DashboardComponent },
  { path: ''            , redirectTo: 'dashBoard', pathMatch: 'full' },
  { path: '**'          , redirectTo: 'dashBoard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
