import { HttpInterceptor, HttpInterceptorFn ,HttpRequest, HttpHandler, HttpEvent  } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class customInterceptor implements HttpInterceptor  {
 

  // This is just an example of how to get the token, modify it as per your app logic
  private getToken(): string | null {
    // For example, retrieve the token from localStorage or sessionStorage
    return localStorage.getItem('token');
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.getToken();

    // If token exists, clone the request and add the token to the headers
    if (token) {
      const cloned = req.clone({
        headers: req.headers.set('Authorization', `Bearer ${token}`)
      });
      return next.handle(cloned);
    }

    // If no token, just pass the original request through
    return next.handle(req);
  }
};
