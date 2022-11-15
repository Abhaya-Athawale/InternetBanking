import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Transaction } from '../Models/Transaction';


@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  

  constructor(private http:HttpClient) { }

  path: string = "http://localhost:44348/api/Transaction";
  public Add(item: Transaction): Observable<any> {
    console.log(item);
    return this.http.post(this.path + "/TransactionManagement", item);
  }

}
