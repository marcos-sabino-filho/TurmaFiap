import { Component } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  tarefasArray: string[] = [];

  adicionarTarefa(valor: string) {
    this.tarefasArray.push(valor);
    console.log(`Adicionando a tarefa: ${valor}`);
  }

  removerTarefa(valor: string) {
    for (let i = this.tarefasArray.length; i >= 0; i--) {
      if (valor == this.tarefasArray[i]) {
        this.tarefasArray.splice(i, 1);
      }
    }
  }

  constructor() {
  }
}
