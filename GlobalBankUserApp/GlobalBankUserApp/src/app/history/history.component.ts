import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Transaction } from '../Models/Transaction';
import { HistoryService } from '../Services/history.service';


@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  list: Transaction[]=[];
  transacId: number = 0;
  customerId: number=0;
  accntId: number=0;
  transacType: string="";
  transacAmnt: number=0;
  transacDate: string="";
  obj: Transaction |undefined;
  errmsg: string="";
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
