import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './Dashboard/dashboard/dashboard.component';
import { RegisterComponent } from './register/register.component';


export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path:'register',component:RegisterComponent,pathMatch:'full'},
    { path:'dashboard' ,component:DashboardComponent , pathMatch:'full' }
  ]; 