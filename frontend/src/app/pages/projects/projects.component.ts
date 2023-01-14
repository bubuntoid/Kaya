import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {
  
  projects: any[];
  name;

  constructor(private authService: AuthService) {   }

  ngOnInit() {
    this.name = this.authService.getUserName();
    
    this.authService.fetchMyProfile(() => {
      this.projects = this.authService.getProjects();
      console.log(this.projects);
    });
  }

  
}
