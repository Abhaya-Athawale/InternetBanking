import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  
  constructor() { }

  ngOnInit(): void {
  }

  onClickSubmit(data: any) {
    const target = data.target
    const cname = target.querySelector('#cname').value;
    const fname = target.querySelector('#fname').value;
    const lname = target.querySelector('#lname').value;
    const city = target.querySelector('#city').value;
    const occupation = target.querySelector('#occ').value;
    const birthday = target.querySelector('#birthday').value;

    /*Insert code here to post these data to api*/
  }

}
