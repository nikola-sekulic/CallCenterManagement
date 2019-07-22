import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { HttpModule } from '@angular/http';

@Injectable()
export class EmployeeService {

  constructor(private http: HttpClient) { }

  getDesignations() {
    return this.http.get('/api/desi');
  }

}
