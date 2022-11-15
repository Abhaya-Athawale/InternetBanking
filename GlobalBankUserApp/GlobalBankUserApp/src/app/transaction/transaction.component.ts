import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Transaction } from '../Models/Transaction';
import { TransactionService } from '../Services/transaction.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {

  list: Transaction[]=[];
  customerId: number=0;
  transacType: string="";
  transacAmnt: number = 0;
  obj: Transaction|undefined;
  errmsg: string="";
  display: boolean = false;
  transacId: number = 0;
  accntId: number = 0;
  transacDate?: Date ;

  constructor(private transactionService: TransactionService) { }

  ngOnInit(): void {
  }

  public Add() {
    this.obj = new Transaction();
    this.obj.transacId = this.transacId;
    this.obj.customerId = this.customerId;
    this.obj.accntId = this.accntId;
    this.obj.transacType = this.transacType;
    this.obj.transacAmnt = this.transacAmnt;
    this.obj.transacDate = this.transacDate;

    alert("Details added successfully");

    //console.log(this.cid);
    this.transactionService.Add(this.obj).subscribe((response: any) => {
      console.log(response);
    }, (error: any) => {
      console.log(error)
      console.log(error.error.text)
    })
  }
}
