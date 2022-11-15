import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from "rxjs";
import { observableToBeFn } from "rxjs/internal/testing/TestScheduler";
import { Account } from "../Models/Account";

@Injectable({
  providedIn: 'root'
})
export class UserLoanService {
  header: any;
  Url = "http://localhost:44348/api/Account";
  constructor(private http: HttpClient) {

  }
  userLoan(obj: Account, amount: number): Observable<any> {
    console.log(obj);
    const data = { obj, amount };
    return this.http.post(this.Url + '/Applyloan',data);
  }
}
