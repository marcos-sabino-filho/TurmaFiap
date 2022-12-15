import { ITarefaDto } from './../interfaces/ITarefaDto';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tarefa-editar',
  templateUrl: './tarefa-editar.component.html',
  styleUrls: ['./tarefa-editar.component.css']
})
export class TarefaEditarComponent {
  tarefaDto: ITarefaDto = { id: 0, nome: '' };

  AtualizarTarefa() {
    // atualizar a informação
    // redirecionar para tela de lista
    this.router.navigate(['lista']);
  }

  constructor(private route: ActivatedRoute, private router: Router) {
    let idRecebido: number;
    this.route.paramMap.subscribe(params => {
      idRecebido = Number(params.get('id'));
      console.log(`Id que recebi para detalhar e atualizar as informações: ${idRecebido}`);
    });
  }
}
