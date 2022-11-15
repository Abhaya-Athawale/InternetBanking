import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { Customer } from '../Models/Customer';
import { UserRegisterService } from '../Services/user-registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  obj: Customer | undefined;
  customerId: string = "";
  firstName: string = "";
  lastName: string = "";
  middleName: string = "";
  customerCity: string = "";
  customerContactNo: string = "";
  customerOccupation: string = "";
  customerDob: string = "";
  password: string = "";

  constructor(private userRegisterService: UserRegisterService, private router: Router) { }

  ngOnInit(): void {

  }
  registerUser() {
    this.obj = new Customer();
    this.obj.firstName = this.firstName;
    this.obj.lastName = this.lastName;
    this.obj.middleName = this.middleName;
    this.obj.customerCity = this.customerCity;
    this.obj.customerContactNo = this.customerContactNo;
    this.obj.customerOccupation = this.customerOccupation;
    this.obj.customerDob = this.customerDob;
    this.obj.password = this.password;
    //console.log(this.obj);
    this.userRegisterService.userRegister(this.obj).
      subscribe((response: Response) => {
        if (response != null) {
          console.log("registered successfully!!");
          this.router.navigate(['/menu']);
        }
      },
        
          (error) => console.log(error));
  }
}
