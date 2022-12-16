import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { map } from 'rxjs';
import { IAlunoDto } from '../interfaces/IAlunoDto';

@Component({
  selector: 'app-alunos-lista',
  templateUrl: './alunos-lista.component.html',
  styleUrls: ['./alunos-lista.component.css']
})
export class AlunosListaComponent {
  listaAlunos: IAlunoDto[] = [];
  alunoSelecionado!: IAlunoDto;
  telaParaApresentar = 'lista';

  constructor(private http: HttpClient, private router: Router) {
    this.listarTodos();
  }

  listarTodos() {
    // LIMPAR A LISTA ANTES DE PREENCHER
    this.listaAlunos = [];

    this.http
      .get('https://localhost:7088/ListarTodos')
      .pipe(
        map((response: any) => {
          return Object.values(response);
        })
      )
      .subscribe((data) => {
        for (let index = 0; index < data.length; index++) {
          let conteudoJson: any = data[index];
          this.listaAlunos.push(conteudoJson as IAlunoDto);
        }
      });
  }

  detalhar(id: number) {
    this.telaParaApresentar = 'detalhe';

    for (let i = 0; i < this.listaAlunos.length; i++) {
      if (id == this.listaAlunos[i].id) {
        this.alunoSelecionado = this.listaAlunos[i];
        break;
      }
    }
  }

  fecharDetalhes = () => {
    this.telaParaApresentar = 'lista';
  }

  removerAluno(id: number) {
    this.http.delete(`https://localhost:7088/Delete?id=${id}`)
      .subscribe((data) => {
        console.log(`Linhas executadas no método de remover do banco ${JSON.stringify(data)}`);
        this.listarTodos();
      });
  }

  editarAluno(id: number) {
    this.router.navigate([`editarAluno/${id}`]);
  }

  adicionarAluno(){
    this.router.navigate([`editarAluno`]);
  }

}
