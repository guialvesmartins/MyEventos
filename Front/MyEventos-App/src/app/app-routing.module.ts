import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { PerfilComponent } from './components/perfil/perfil.component';

const routes: Routes = [
  { path: 'eventos'     , component: EventosComponent },
  { path: 'contatos'    , component: ContatosComponent },
  { path: 'perfil'      , component: PerfilComponent },
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
