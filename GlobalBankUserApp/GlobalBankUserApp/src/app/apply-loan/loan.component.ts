import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Account } from '../Models/Account';
import { UserLoanService } from '../Services/user-loan.service';

@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.css']
})
export class LoanComponent implements OnInit {


  HttpClient: any;
  errorMessage: any;
  customerId: number = 0;
  branch: string = "";
  amount: number = 0;
  obj: Account | undefined;
  token: string = "";

  constructor(private userLoanService: UserLoanService, private router: Router) { }


  ngOnInit() {
  }
  onClickSubmit() {
    this.obj = new Account();
    this.obj.customerId = this.customerId;
    this.obj.branch = this.branch;
    this.userLoanService.userLoan(this.obj, this.amount)
      .subscribe((response) => {
        if (response.status2 == 200) {
          this.router.navigate(['/menu']);
        }
        console.log(response);
      },
        (error) => {

          console.log(error);
        }
      )
  }
}
