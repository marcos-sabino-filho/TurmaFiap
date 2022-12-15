import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { IAlunoDto } from './../interfaces/IAlunoDto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-alunos-editar',
  templateUrl: './alunos-editar.component.html',
  styleUrls: ['./alunos-editar.component.css']
})
export class AlunosEditarComponent implements OnInit{
  aluno!: IAlunoDto;

  constructor(private http:HttpClient, private route: ActivatedRoute, private router: Router){
    let idRecebido: number;
    this.route.paramMap.subscribe(params => {
      idRecebido = Number(params.get('id'));
    });
  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

}
