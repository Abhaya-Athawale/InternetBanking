import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './registration/registration.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoanComponent } from './loan/loan.component';
import { UseropsComponent } from './userops/userops.component';
import { HistoryComponent } from './history/history.component';


//import { UserregistrationService } from './userregistration.service';
//import { LoanComponent } from './loan/loan.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    LoanComponent,
    UseropsComponent,
    HistoryComponent,
    //HistoryComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path: '',
        component: RegistrationComponent
      },
      {
        path: 'loan',
        component: LoanComponent
      },
      {
        path: 'userops',
        component: UseropsComponent
      },
      {
        path: 'history',
        component: HistoryComponent
      }
    ]),
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

