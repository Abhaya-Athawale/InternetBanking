import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { LoanComponent } from "./apply-loan/loan.component";
import { HistoryComponent } from "./history/history.component";
import { PageNotFoundComponent } from "./page-not-found.component";
import { TransactionComponent } from "./transaction/transaction.component";
import { UserLoginComponent } from "./user-login/user-login.component";
import { UseropsComponent } from "./user-ops/userops.component";
import { RegistrationComponent } from "./user-registration/registration.component";

const routes: Routes = [
  { path: "login", component: UserLoginComponent },
  { path: "register", component: RegistrationComponent },
  { path: "menu", component: UseropsComponent },
  { path: "loan", component: LoanComponent },
  { path: "history", component: HistoryComponent },
  {path:"transaction",component:TransactionComponent},
  { path: "", component: UserLoginComponent, pathMatch: "full" },
  {path:"**",component:PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
