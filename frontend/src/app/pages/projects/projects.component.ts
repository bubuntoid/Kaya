import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProjectModalComponent } from 'src/app/modals/project-modal/project-modal.component';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {
  
  projects: any[];
  name;

  constructor(private authService: AuthService, private modalService : NgbModal) {   }

  ngOnInit() {
    this.name = this.authService.getUserName();
    
    this.authService.fetchMyProfile(() => {
      this.projects = this.authService.getProjects();
      console.log(this.projects);
    });
  }

  open() {
		const modalRef = this.modalService.open(ProjectModalComponent);
    modalRef.componentInstance.modalTitle = 'New project';
    modalRef.componentInstance.buttonText = 'Save';
    modalRef.componentInstance.onClick = () =>
    {
      window.alert('zxc');
    }
	}
  
}
