import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { decode } from 'punycode';
import { LeftNavComponent } from "../left-nav/left-nav.component";
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [LeftNavComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {
/**
 *
 */
username :String = '';
userData: any;
constructor(private router: Router) {


}
  ngOnInit(): void {
    this.checkAuthentication();
  }
  checkAuthentication(): void {

    // Get user data from local storage
    const userJson = localStorage.getItem('username');

    // Check if userJson exists and is valid
    if (userJson) {
      this.userData =userJson;
      
      // Assuming decode function checks for token validation or some logic
      if (this.userData && this.userData != "undefined") {
        this.username = this.userData;
        console.log('User is authenticated:', this.userData);
      } else {
        this.redirectToLogin();
      }
    } else {
      this.redirectToLogin();
    }
  }
  // Method to decode and validate user data
  decode(userData: any): boolean {
    // Add your custom decoding logic (e.g., JWT token validation) here
    return userData && userData.isValid; // Example logic, adjust based on your needs
  }

  // Redirect to login page
  redirectToLogin(): void {
    console.log('User not authenticated, redirecting to login...');
    this.router.navigate(['/login']);
  }
  logout(){
    localStorage.removeItem('username');
    this.router.navigate(['/login']); }
}
