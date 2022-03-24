import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Trend } from '../utils/trend';

@Injectable({
  providedIn: 'root'
})
export class TrendService {

  baseUrl = environment.apiURL + 'Trends/trends'

  constructor(
    private httpClient : HttpClient
  ) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  getTrends(): Observable<Trend[]> {
    return this.httpClient.get<Trend[]>(this.baseUrl)
      .pipe(
        retry(2),
        catchError(throwError))
  }

}
