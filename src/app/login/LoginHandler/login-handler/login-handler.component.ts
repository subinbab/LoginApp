import { Component , Input, OnInit , SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';  // Import Router for navigation
import { HttpClientModule } from '@angular/common/http';
import { LoginService } from './login-api';
import { response } from 'express';
import { error } from 'console';

@Component({
  selector: 'app-login-handler',
  standalone: true,
  imports: [
    HttpClientModule
  ],
  templateUrl: './login-handler.component.html',
  styleUrl: './login-handler.component.scss'
})
export class LoginHandlerComponent implements OnInit {
  constructor(private router: Router, private loginService : LoginService) {}  // Inject the Router service
  @Input() username: string = '';
   @Input() password: string = '';
   login :any;
  userData: {
    username: string;
    password: string;
  } = {
    username: '',
    password: ''
  };

  key = "encrypt!135790";
  ngOnChanges(changes: SimpleChanges): void {
    // Check for changes on username or password
    if (changes['username']) {
      this.onUsernameChange(changes['username'].currentValue);
    }
    if (changes['password']) {
      this.onPasswordChange(changes['password'].currentValue);
    }

  }
  onUsernameChange(newUsername: string) {
    console.log(`Username changed to: ${newUsername}`);
    // Your logic here
  }

  onPasswordChange(newPassword: string) {
    console.log(`Password changed to: ${newPassword}`);
    // Your logic here
  }
  ngOnInit(): void {
    this.login = this.loginService;
  }
  //To encrypt input data
public encrypt(password: string): string {
  return CryptoJS.AES.encrypt(password, this.key).toString();
}
  CheckLogin(){
    console.log("This is child components :"+this.userData.username)
    this.login.postLogin("http://localhost:5073/api/Login/SignIn",{
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "username": this.username,
      "password": this.encrypt(this.password),
      "loginDate": "2024-09-25T04:24:25.422Z",
      "email": "string"
    }).subscribe(
      (response : any)=>{
        console.log(response);
        if(response.isSuccess===true){
          console.log(response);
          localStorage.setItem('username',response.username)
          localStorage.setItem('token',response.token)
          this.router.navigate(['/dashboard']);
        }
      },
      (error : any)=>{
        console.log(error)
      }
    )
    
  }
}
