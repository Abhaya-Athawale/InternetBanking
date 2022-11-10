import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserregistrationService } from './userregistration.service';
import { Customer } from '../Models/customer.model';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  list: Customer[];
  cid: number;
  FirstName: string;
  LastName: string;
  CustomerCity: string;
  Occupation: string;
  CustomerDob: Date;
  obj: Customer;
  errmsg: string;
  display: boolean = false;
  constructor(private userregistrationService : UserregistrationService) { }

  ngOnInit(): void {
  }

  onClickSubmit(data: any) {

    /*this.userregistrationService.postdata(data);*/

    /*Insert code here to post these data to api*/
  }

  public Add() {
    this.obj = new Customer();
    this.obj.cid = this.cid;
    this.obj.FirstName= this.FirstName;
    this.obj.LastName = this.LastName;
    this.obj.CustomerCity = this.CustomerCity;
    this.obj.Occupation = this.Occupation;
    this.obj.CustomerDob = this.CustomerDob;

    console.log(this.cid);
    this.userregistrationService.Add(this.obj).subscribe((response : any) => {
      console.log(response);
    }, (error : any) => {
      console.log(error)
      console.log(error.error.text)
    })
  }
  

}
