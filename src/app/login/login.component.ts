import { Component, OnInit , ViewChild } from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { LoginHandlerComponent } from './LoginHandler/login-handler/login-handler.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule,MatButtonModule, MatDividerModule, MatIconModule,LoginHandlerComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  username : String ="";
  password : String ="";
  user: {
    username: String;
    password: String;
  } = {
    username: '',
    password: ''
  };
  
ngOnInit(): void {
  
}
// Get reference to ChildComponent
@ViewChild(LoginHandlerComponent) childComponent!: LoginHandlerComponent;
onSubmit(){
  console.log("Entered Credentials : "+this.username+" and "+this.password);
  this.user.username = this.username;
  this.user.password = this.password;
  this.childComponent.CheckLogin();
}
}
