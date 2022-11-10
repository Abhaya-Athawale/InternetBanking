import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Transaction } from '../Models/transaction.model';
import { HistoryService } from './history.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  list: Transaction[];
  transacId: number;
  customerId: number;
  accntId: number;
  transacType: string;
  transacAmnt: string;
  transacDate: Date;
  obj: Transaction;
  errmsg: string;
  dispaly: boolean = false

  constructor(private service: HistoryService, private router: Router) {
    this.service.GetAll().subscribe(i => {
      this.list = i
      if (this.list.length > 0) {
        this.dispaly = true;
      }
      console.log(this.list)
    })
  }

  ngOnInit(): void {
  }

}
