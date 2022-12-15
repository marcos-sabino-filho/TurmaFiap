import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { IAlunoDto } from './../interfaces/IAlunoDto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-alunos-editar',
  templateUrl: './alunos-editar.component.html',
  styleUrls: ['./alunos-editar.component.css']
})
export class AlunosEditarComponent implements OnInit {
  aluno!: IAlunoDto;
  idRecebido!: number;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idRecebido = Number(params.get('id'));
    });
  }

  ngOnInit(): void {
    this.aluno = {
      id: this.idRecebido ?? 0,
      nome: '',
      documento: '',
      aniversario: '',
      matricula: '',
      ultimoNome: ''
    }
  }

  salvar() {
    console.log(`Objeto para salvar: ${JSON.stringify(this.aluno)}`);
  }

}
