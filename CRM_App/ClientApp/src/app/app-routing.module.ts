import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { CitizenlistComponent } from './components/citizen/citizenlist/citizenlist.component';
import { ForeaslistComponent } from './components/foreas/foreaslist/foreaslist.component';
import { HomeComponent } from './components/shared/home/home.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'login' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'citizenlist', component: CitizenlistComponent },
  { path: 'home', component: HomeComponent }
  //{ path: 'citizenlist', component: CitizenlistComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
