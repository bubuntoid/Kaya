import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'ni-chart-bar-32 text-primary', class: '' },
    { path: '/events', title: 'Events',  icon:'ni-single-copy-04 text-primary', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;
  public name;
  public projects: any[];

  constructor(public router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
   });
   this.name = this.authService.getUserName();
   this.projects = this.authService.getProjects();
  }

  isVisible() {
    return this.router.url != '/projects' && 
      this.router.url != '/user-profile';
  }
  
  logout()  {
    this.authService.logout();
  }

}
