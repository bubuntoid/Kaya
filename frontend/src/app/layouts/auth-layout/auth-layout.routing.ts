import { Routes } from '@angular/router';
import { UnAuthGuardService } from 'src/app/guarding/un-auth-guard.service';

import { LoginComponent } from '../../pages/login/login.component';
import { RegisterComponent } from '../../pages/register/register.component';

export const AuthLayoutRoutes: Routes = [
    {
        path: 'login',
        component: LoginComponent,
        canActivate: [UnAuthGuardService],
    },
    {
        path: 'register',
        component: RegisterComponent,
        canActivate: [UnAuthGuardService],
    }
];
