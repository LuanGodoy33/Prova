import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IUsuario } from "../interface/IDados";
import { environment } from "../enviroment.ts/enviroment";


@Injectable({
    providedIn: 'root'
})

export class Service {
    private url = environment.Url;
    private fakeToken = "Fake-Token";

    constructor(private http: HttpClient) { }

    private async Token(): Promise<HttpHeaders> {
        return new HttpHeaders({
            'Authorization': this.fakeToken
        });
    }

    public async Adicionar(usuario: IUsuario) {
        const httpOptions = await this.Token();
        return this.http.post<IUsuario>(`${this.url}/api/Usuario/Adicionar/`, usuario, { headers: httpOptions }).toPromise();
    }

    public async Alterar(usuario: IUsuario) {
        const httpOptions = await this.Token();
        return this.http.put<IUsuario>(`${this.url}/api/Usuario/Alterar/${usuario.id}`, usuario, { headers: httpOptions }).toPromise();
    }

    public async GetBuscarPorId(id: number) {
        const httpOptions = await this.Token();
        return this.http.get<IUsuario>(`${this.url}/api/Usuario/BuscarPorId/${id}`, { headers: httpOptions }).toPromise();
    }

    public async GetBuscarTodos(): Promise<IUsuario[] | undefined> {
        const httpOptions = await this.Token();
        const response = await this.http.get<IUsuario[]>(`${this.url}/api/Usuario/BuscarTodos`, { headers: httpOptions }).toPromise();
        return response;
    }

    public async Deletar(id: number) {
        const httpOptions = await this.Token();
        return this.http.delete(`${this.url}/api/Usuario/Deletar/${id}`, { headers: httpOptions }).toPromise();
    }
}