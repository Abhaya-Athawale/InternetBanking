import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Transaction } from '../Models/transaction.model';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {

  path: string = "http://localhost:5201/api/Transaction/";
  constructor(private http: HttpClient) { }

  public GetAll(): Observable<any> {
    return this.http.get(this.path + "GetTransactions")
  }
}
