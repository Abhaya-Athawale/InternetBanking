import { Component, OnInit } from '@angular/core';
import { LoginService } from '../Services/user-login.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
  pageTitle: string = 'User Login';


  constructor(private loginService:LoginService) { }

  ngOnInit(): void {

  }

}
