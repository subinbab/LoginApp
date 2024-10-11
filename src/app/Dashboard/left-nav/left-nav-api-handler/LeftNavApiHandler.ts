import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class navbarapihandler{
    private apiUrl = 'http://localhost:5073/api/dashboard/GetService'; // Adjust the URL as necessary

    constructor(private http: HttpClient) { }
  
    postLogin( url :string , data : any): Observable<any> {
      console.log("Entered into api call section")
  
      return this.http.post<any>(url,data);
    
}
}
 


