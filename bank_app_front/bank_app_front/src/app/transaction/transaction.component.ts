import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Tranmgmt } from '../Models/tranmgmt.model';
import { TransactionService } from './transaction.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {

  list: Tranmgmt[];
  customerId: number;
  transacType: string;
  transacAmnt: number;
  obj: Tranmgmt;
  errmsg: string;
  display: boolean = false;

  constructor(private transactionService: TransactionService) { }

  ngOnInit(): void {
  }

  public Add() {
    this.obj = new Tranmgmt();
    //this.obj.transacId = this.transacId;
    this.obj.customerId = this.customerId;
    //this.obj.accntId = this.accntId;
    this.obj.transacType = this.transacType;
    this.obj.transacAmnt = this.transacAmnt;
    //this.obj.transacDate = this.transacDate;

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
