import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from "rxjs";
import { CustomerLogin } from "../Models/CustomerLogin";
import { observableToBeFn } from "rxjs/internal/testing/TestScheduler";

@Injectable({
  providedIn:'root'
})
export class LoginService {
  header: any;
  Url = "http://localhost:44348/api/customerLogin";
  constructor(private http: HttpClient) {
    
  }
  userLogin(obj: CustomerLogin): Observable<any> {
    console.log(obj);
    return this.http.post(this.Url + '/login', obj);
  }
  }

