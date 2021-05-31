import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-department',
  templateUrl: './show-department.component.html',
  styleUrls: ['./show-department.component.css']
})
export class ShowDepartmentComponent implements OnInit {

  constructor(private service:SharedService) { }

  DepartmentList:any=[];

  ngOnInit(): void {
    this.refreshDepartmentList();
  }

  refreshDepartmentList(){
    this.service.getDepartmentList().subscribe(data=>{
      this.DepartmentList=data;
    });
  }
}
