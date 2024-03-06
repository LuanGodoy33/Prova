import { Component } from '@angular/core';
import { Service } from './service/service';
import { IUsuario } from './interface/IDados';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  id?: number;
  nome!: string;
  mostrarInputNome: boolean = false;


  constructor(private service: Service) { }

  async Adicionar() {
    if (!this.nome) {
      console.log("Por favor, insira um nome");
      return;
    }

    const novoUsuario: IUsuario = {
      nome: this.nome,
    };

    const usuarioAdicionado = await this.service.Adicionar(novoUsuario);
    console.log("Usuário adicionado com sucesso:", usuarioAdicionado);
  }

  Alterar() {
    if (!this.id) {
      this.mostrarInputNome = true;
      console.log("Por favor, insira um ID válido.");
      return;
    }

    this.service.Alterar({ id: this.id, nome: this.nome })
      .then(res => {
        console.log('Nome alterado com sucesso:', res);
      })
  }

  async ObterPorId() {
    if (!this.id) {
      console.log("Por favor, insira um ID válido.");
      return;
    }

    const usuario = await this.service.GetBuscarPorId(this.id);
    console.log("Usuário encontrado:", usuario);
  }

  async ObterTodos() {
    this.service.GetBuscarTodos().then(usuario => console.log(usuario))
  }

  async Deletar() {
    if (!this.id) {
      console.log("Por favor, insira um ID válido.");
      return;
    }

    await this.service.Deletar(this.id);
    console.log("Usuário deletado com sucesso.");
  }
}
