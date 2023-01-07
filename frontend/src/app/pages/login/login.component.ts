import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  login: any = '';
  password: any = '';

  constructor(private authService : AuthService) {}

  ngOnInit() {
  }
  ngOnDestroy() {
  }

  onLoginClick(){
    this.authService.authorize(this.login, this.password);
  }

}
