import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../../services/employee.service';
import 'rxjs/add/Observable/forkJoin';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  designations: any;
  employee: any;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.employeeService.getDesignations().subscribe(designations => {
      this.designations = designations;


     
    });
    
}
  onMakeChange() {
    var selectedDesignation = this.designations.find(m => m.id == this.employee.designationId);
  }
}
