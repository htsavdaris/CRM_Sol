import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { User } from '../models/user';
import { Userauth } from '../models/userauth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public myAppUrl: string;
  myApiUrl: string;
  private isLoggedIn: boolean;
  public isLoggedIn$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

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
    return this.isLoggedIn;
  }

  authenticate(user): Observable<Userauth> {
    return this.http.post<User>(this.myAppUrl + this.myApiUrl + 'authenticate', JSON.stringify(user), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  register(user): Observable<User> {
    console.log('User');
    console.log(JSON.stringify(user));
    return this.http.post<User>(this.myAppUrl + this.myApiUrl + 'register', JSON.stringify(user), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  logout() {
    localStorage.removeItem('authtoken');
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
