import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map, Observable } from "rxjs";
import { Customer } from "../Models/Customer";

@Injectable({
  providedIn: 'root'
})
export class UserRegisterService {
  header: any;
  Url = "http://localhost:44348/api/customer";
  constructor(private http: HttpClient) {

  }
  userRegister(obj: Customer): Observable<any>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post(this.Url + "/register", obj, {headers:this.header});
  }
}
