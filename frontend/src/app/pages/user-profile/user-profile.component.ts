import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {


  name;

  constructor(private authService : AuthService) { }

  ngOnInit() {
    this.name = this.authService.getUserName();
  }

}
