import { Component, OnInit } from '@angular/core';
import { Loan } from '../Models/loan.model';
import { LoanService } from './loan.service';

@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.css']
})
export class LoanComponent implements OnInit {

  constructor(private loanService: LoanService) { }

  list: Loan[];
  cid: number;
  branch: string;
  amount: number;
  obj: Loan;
  errmsg: string;
  display: boolean = false;

  ngOnInit(): void {
  }

  onClickSubmit(data: any) {
    const target = data.target
    const cid = target.querySelector('#cid').value;
    const branch = target.querySelector('#branch').value;
    const amt = target.querySelector('#amt').value;

    /*Insert code here to post these data to api*/
  }

  public Add() {
    this.obj = new Loan();
    this.obj.cid = this.cid;
    this.obj.branch = this.branch;
    this.obj.amount = this.amount;

    console.log(this.cid);
    this.loanService.Add(this.obj).subscribe((response: any) => {
      console.log(response);
    }, (error: any) => {
      console.log(error)
      console.log(error.error.text)
    })
  }

}
