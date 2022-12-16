import { HttpClient } from '@angular/common/http';
import { IAlunoDto } from './../interfaces/IAlunoDto';
import { Component, OnInit } from '@angular/core';
import { ITurmaDto } from '../interfaces/ITurmaDto';
import { map } from 'rxjs';

@Component({
  selector: 'app-turma-alunos',
  templateUrl: './turma-alunos.component.html',
  styleUrls: ['./turma-alunos.component.css']
})
export class TurmaAlunosComponent implements OnInit {

  listaAlunos: IAlunoDto[] = [];
  listaTurmas: ITurmaDto[] = [];

  idAlunoSelecionado: number = 0;
  idTurmaSelecionada: number = 0;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get('https://localhost:7088/ListarTodos')
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

    this.http.get('https://localhost:7088/ListarTodas')
      .pipe(
        map((response: any) => {
          return Object.values(response);
        })
      )
      .subscribe((data) => {
        for (let index = 0; index < data.length; index++) {
          let conteudoJson: any = data[index];
          this.listaTurmas.push(conteudoJson as ITurmaDto);
        }
      });
  }

  salvarAlteracao() {
    console.log(`idAluno: ${this.idAlunoSelecionado} - idTurma: ${this.idTurmaSelecionada}`);
  }
}
