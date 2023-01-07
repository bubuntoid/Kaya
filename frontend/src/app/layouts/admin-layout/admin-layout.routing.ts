import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { AuthGuardService } from 'src/app/guarding/auth-guard.service';
import { ProjectsComponent } from 'src/app/pages/projects/projects.component';

export const AdminLayoutRoutes: Routes = [
    {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [AuthGuardService],
    },
    {
        path: 'user-profile',
        component: UserProfileComponent,
        canActivate: [AuthGuardService],
    },
    {
        path: 'events',
        component: TablesComponent,
        canActivate: [AuthGuardService],
    },
    {
        path: 'projects',
        component: ProjectsComponent,
        canActivate: [AuthGuardService],
    },
];
