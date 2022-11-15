import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Transaction } from '../Models/Transaction';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {

  path: string = "http://localhost:44348/api/Transaction/";
  constructor(private http: HttpClient) { }

  public GetAll(): Observable<any> {
    return this.http.get(this.path + "GetTransactions")
  }
}
