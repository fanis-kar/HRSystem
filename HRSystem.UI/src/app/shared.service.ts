import { Injectable } from '@angular/core';
import { fromEventPattern } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:56890/api";

  constructor(private http: HttpClient) { }

  getDepartmentList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/1.0/department');
  }
}
