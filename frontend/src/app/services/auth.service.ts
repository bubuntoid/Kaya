import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  url: string = `${environment.apiUrl}/auth/`;

  private USER_TOKEN_ITEM_NAME = "userPrivateKey";

  private USER_CREDENTIALS_ITEM_NAME = "userData"

  constructor(private http: HttpClient) { }

  public authorize(login: string, password: string) {
    this.http.post<any>(this.url + 'login', {login, password}).subscribe(response => {
      localStorage.setItem(this.USER_TOKEN_ITEM_NAME, response.privateKey);
      localStorage.setItem(this.USER_CREDENTIALS_ITEM_NAME, JSON.stringify(response));

      window.location.reload();

      console.log(response);
    }, error => {

      // todo: handle error

    });
  }

  public register(name: string, login: string, password: string) {
    this.http.post<any>(this.url + 'register', {login, name, password}).subscribe(response => {
      localStorage.setItem(this.USER_TOKEN_ITEM_NAME, response.privateKey);
      localStorage.setItem(this.USER_CREDENTIALS_ITEM_NAME, JSON.stringify(response));

      window.location.reload();

      console.log(response);
    }, error => {

      // todo: handle error

    });
  }

  public isAuthenticated(): boolean {
    var obj = localStorage.getItem(this.USER_TOKEN_ITEM_NAME);

    if (obj != undefined && obj != null) {
      return true;
    }

    return false;
  }

  public logout() {
    localStorage.clear();
    window.location.reload();
  }
}
