import { AlunosListaComponent } from './alunos-lista/alunos-lista.component';
import { TarefaEditarComponent } from './tarefa-editar/tarefa-editar.component';
import { TarefasListaComponent } from './tarefas-lista/tarefas-lista.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'lista', component: TarefasListaComponent },
  { path: 'editar/:id', component: TarefaEditarComponent },
  { path: 'listaalunos', component: AlunosListaComponent },
  { path: '**', redirectTo: 'lista' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
