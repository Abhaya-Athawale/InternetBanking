import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userops',
  templateUrl: './userops.component.html',
  styleUrls: ['./userops.component.css']
})
export class UseropsComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  ApplyForLoan() {
    this.router.navigate(['/loan']);
  }

  CreditOrDebit() {
    this.router.navigate(['/transaction']);
  }
  ShowRecentTransactions() {
    this.router.navigate(['/history']);
  }

}
