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

    // BUSCAR NA API OS DADOS DO ALUNO QUE RECEBEMOS O ID NA URL
    if (this.idRecebido) {
      this.http
        .get(`https://localhost:7088/ListarPorId/${this.idRecebido}`)
        .subscribe((data) => {
          this.aluno = data as IAlunoDto;
        });
    }

  }

  salvar() {

    if (this.validarInformacoes()) {
      console.log(`Objeto para salvar: ${JSON.stringify(this.aluno)}`);

      if (this.aluno.id == 0) {

        // if(!this.aluno.aniversario || this.aluno.aniversario==''){
        //   console.log('erro na data');
        // this.aluno.aniversario = '0001-01-01';
        // }

        this.http.post('https://localhost:7088/cadastraraluno', this.aluno)
          .subscribe((data) => {
            this.router.navigate(['listaalunos']);
          });

      } else {
        this.http.patch('https://localhost:7088/atualizar', this.aluno)
          .subscribe((data) => {
            this.router.navigate(['listaalunos']);
          });
      }

    } else {
      console.log('Erro na validação');
      // TRATAMENTO DE ERRO
      // ALERTA
      // BORDA VERMELHA
    }
  }

  validarInformacoes(): boolean {
    if (this.aluno.nome == '') {
      return false;
    }

    // VALIDAR COM REGEX

    return true;
  }

}
