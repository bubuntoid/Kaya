import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss']
})
export class TablesComponent implements OnInit {

  public headerKeyFilter = '';
  public tagFilter = '';

  constructor() { }

  ngOnInit() {
  }

  updateOptions(tag){
    this.tagFilter = tag;
  }

}
