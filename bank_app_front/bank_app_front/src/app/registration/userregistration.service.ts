import { json } from '@angular-devkit/core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../Models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class UserregistrationService {
  http: any;

  constructor() { }
  /*
  Add(data: any) {
    const formData = new FormData(data.target);
    const value = Object.fromEntries(formData.entries());
    const target = (data.target);
    const cid = target.querySelector('#cid').value;
    const fname = target.querySelector('#fname').value;
    const lname = target.querySelector('#lname').value;
    const city = target.querySelector('#city').value;
    const occ = target.querySelector('#occ').value;
    const bday = target.querySelector('#birthday').value;
    //alert(cid);
    
    
    console.log(JSON.stringify(value));
    
    this.http
      .post('http://localhost:5201/api/create-user', JSON.stringify(value))
      .subscribe({
        next: (response: any) => console.log(response),
        error: (error: any) => console.log(error),
    });
    */
  path: string = "http://localhost:5201/api/customer/";
  public Add(item: Customer): Observable<any> {
    console.log(item);
    return this.http.post(this.path + "Register", item);
  }
    
  
}
