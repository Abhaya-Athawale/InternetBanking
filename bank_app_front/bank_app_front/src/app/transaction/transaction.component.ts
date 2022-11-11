import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Transaction } from '../Models/transaction.model';
import { TransactionService } from './transaction.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {

  list: Transaction[];
  transacId: number;
  customerId: number;
  accntId: number;
  transacType: string;
  transacAmnt: number;
  transacDate: Date;
  obj: Transaction;
  errmsg: string;
  display: boolean = false;

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
