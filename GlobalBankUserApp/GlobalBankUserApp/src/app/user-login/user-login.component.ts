import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { map, observable } from 'rxjs';
import { CustomerLogin } from '../Models/CustomerLogin';
import { LoginService } from '../Services/user-login.service';


@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
  
    HttpClient: any;
  errorMessage: any;
  customerId: number = 0;
  password: string = "";
  obj: CustomerLogin | undefined;
  token: string = "";

  constructor(private loginService: LoginService,private router:Router) { }


  ngOnInit() {
  }
  onClickSubmit() {
    this.obj = new CustomerLogin();
    this.obj.customerId=this.customerId;
    this.obj.password=this.password;
    console.log(this.obj);
    this.loginService.userLogin(this.obj)
      .subscribe((response) => {
        if (response != null) {
          this.router.navigate(['/menu']);
        }
        else {
          this.router.navigate(['/register']);
        }
      },
        (error) => {
          
          console.log(error);
      }
      )
  }
    
      
  
}
