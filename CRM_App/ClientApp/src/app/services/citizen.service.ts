import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Citizen } from '../models/citizen';

@Injectable({
  providedIn: 'root'
})
export class CitizenService {
  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = 'api/Citizen/';
  }


  getCitizens(): Observable<Citizen[]> {
    return this.http.get<Citizen[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getCitizen(postId: number): Observable<Citizen> {
    return this.http.get<Citizen>(this.myAppUrl + this.myApiUrl + postId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveCitizen(blogPost): Observable<Citizen> {
    return this.http.post<Citizen>(this.myAppUrl + this.myApiUrl, JSON.stringify(blogPost), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateCitizen(postId: number, blogPost): Observable<Citizen> {
    return this.http.put<Citizen>(this.myAppUrl + this.myApiUrl + postId, JSON.stringify(blogPost), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteCitizen(postId: number): Observable<Citizen> {
    return this.http.delete<Citizen>(this.myAppUrl + this.myApiUrl + postId)
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
