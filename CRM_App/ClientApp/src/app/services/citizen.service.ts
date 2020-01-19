import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Citizen } from '../models/citizen';

@Injectable({
  providedIn: 'root'
})
export class CitizenService {
  public myAppUrl: string;
  myApiUrl: string;
  ocitizenList: Array<Citizen>;
  ocitizen: Citizen;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    //this.myAppUrl = 'http://localhost:57653/';
    this.myAppUrl = 'http://localhost:5000/';
    this.myApiUrl = 'api/Citizen/';
  }


  
  getCitizens(): Observable<Citizen[]> {
    return this.http.get<Citizen[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getCitizen(citizenid: number): Observable<Citizen> {
    return this.http.get<Citizen>(this.myAppUrl + this.myApiUrl + citizenid)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveCitizen(citizen): Observable<Citizen> {
    return this.http.post<Citizen>(this.myAppUrl + this.myApiUrl, JSON.stringify(citizen), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateCitizen(citizenid: number, citizen): Observable<Citizen> {
    return this.http.put<Citizen>(this.myAppUrl + this.myApiUrl + citizenid, JSON.stringify(citizen), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteCitizen(citizenid: number): Observable<Citizen> {
    return this.http.delete<Citizen>(this.myAppUrl + this.myApiUrl + citizenid)
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
