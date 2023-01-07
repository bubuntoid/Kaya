import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  login: any = '';
  password: any = '';
  name: any = '';

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  onRegisterClick(){
    this.authService.register(this.name, this.login, this.password);
  }

}
