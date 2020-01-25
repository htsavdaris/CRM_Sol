import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public myAppUrl: string;
  myApiUrl: string;
  private authenticated: boolean;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    //this.myAppUrl = 'http://localhost:57653/';
    this.myAppUrl = 'http://localhost:5000/';
    this.myApiUrl = 'api/User/';
  }


  isAuthenticated(): boolean {
    return this.authenticated;
  }

  authenticate(user): Observable<User> {
    return this.http.post<User>(this.myAppUrl + this.myApiUrl, JSON.stringify(user), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }


  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
