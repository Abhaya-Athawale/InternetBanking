import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Loan } from '../Models/loan.model';

@Injectable({
  providedIn: 'root'
})
export class LoanService {
  http: any;

  constructor() { }

  path: string = "";
  public Add(item: Loan): Observable<any> {
    console.log(item);
    return this.http.post(this.path, item);
  }
}
