import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class UnAuthGuardService implements CanActivate {

  constructor(private authService : AuthService, private router: Router) { }

  canActivate(): boolean {

    if (this.authService.isAuthenticated())
     {
      this.router.navigate(['projects']);
      return false;
    }
    
    return true;
  }
}
