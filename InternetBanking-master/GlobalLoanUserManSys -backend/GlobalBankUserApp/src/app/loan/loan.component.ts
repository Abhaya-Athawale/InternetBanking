import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.css']
})
export class LoanComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  onClickSubmit(data: any) {
    const target = data.target
    const cid = target.querySelector('#cid').value;
    const branch = target.querySelector('#branch').value;
    const amt = target.querySelector('#amt').value;

    /*Insert code here to post these data to api*/
  }
}
