import { IAlunoDto } from './../interfaces/IAlunoDto';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-alunos-detalhe',
  templateUrl: './alunos-detalhe.component.html',
  styleUrls: ['./alunos-detalhe.component.css']
})
export class AlunosDetalheComponent implements OnInit {
  @Input() aluno!: IAlunoDto;
  @Input() fecharDetalhe!: () => void;

  constructor() { }

  ngOnInit(): void {
    console.log(`objeto recebido :${JSON.stringify(this.aluno)}`);
  }

  fechar() {
    this.fecharDetalhe();
  }

}
