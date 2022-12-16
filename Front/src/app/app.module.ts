import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TarefasDetalheComponent } from './tarefas-detalhe/tarefas-detalhe.component';
import { TarefasListaComponent } from './tarefas-lista/tarefas-lista.component';
import { TarefaEditarComponent } from './tarefa-editar/tarefa-editar.component';
import { AlunosListaComponent } from './alunos-lista/alunos-lista.component';
import { AlunosDetalheComponent } from './alunos-detalhe/alunos-detalhe.component';
import { AlunosEditarComponent } from './alunos-editar/alunos-editar.component';
import { TurmaAlunosComponent } from './turma-alunos/turma-alunos.component';

@NgModule({
  declarations: [
    AppComponent,
    TarefasDetalheComponent,
    TarefasListaComponent,
    TarefaEditarComponent,
    AlunosListaComponent,
    AlunosDetalheComponent,
    AlunosEditarComponent,
    TurmaAlunosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
