import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'project-modal',
  templateUrl: './project-modal.component.html',
  styleUrls: ['./project-modal.component.scss'],
})
export class ProjectModalComponent implements OnInit {
  
  @Input() modalTitle;
  @Input() buttonText;
  @Input() onClick;

  @Input() projectName;

	constructor(public activeModal: NgbActiveModal) {}

  ngOnInit() {
    
  }

  click()
  {
    this.onClick();
    this.activeModal.close('Close click')
  }
  
}
