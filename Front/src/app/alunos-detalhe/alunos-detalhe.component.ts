import { IAlunoDto } from './../interfaces/IAlunoDto';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-alunos-detalhe',
  templateUrl: './alunos-detalhe.component.html',
  styleUrls: ['./alunos-detalhe.component.css']
})
export class AlunosDetalheComponent {
  @Input() aluno!: IAlunoDto;
  @Input() fecharDetalhe!: () => void;

  constructor() {

  }

  fechar(){
    this.fecharDetalhe();
  }

}
