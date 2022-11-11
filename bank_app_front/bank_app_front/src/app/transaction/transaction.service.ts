import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tranmgmt } from '../Models/tranmgmt.model';


@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  http: any;

  constructor() { }

  path: string = "http://localhost:5201/api/Transaction/";
  public Add(item: Tranmgmt): Observable<any> {
    console.log(item);
    return this.http.post(this.path + "TransactionManagement", item);
  }

}
