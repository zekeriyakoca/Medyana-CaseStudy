import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Observable ,  throwError, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root', })
export class ApiService {
  constructor(
    private http: HttpClient
  ) {}

  private formatErrors(error: any) {
    return  throwError(error.error);
  }
  private httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http.get(`${environment.backEndUrl}${path}`, { params })
      .pipe(catchError(this.formatErrors));
  }

  put(path: string, body: Object = {}): Observable<any> {
    return this.http.put(
      `${environment.backEndUrl}${path}`,
      JSON.stringify(body),
      this.httpOptions
    ).pipe(catchError(this.formatErrors));
  }

  patch(path: string, body: Object = {}): Observable<any> {
    return this.http.patch(
      `${environment.backEndUrl}${path}`,
      JSON.stringify(body),
      this.httpOptions
    ).pipe(catchError(this.formatErrors));
  }

  post(path: string, body: Object = {}): Observable<any> {
    return this.http.post(
      `${environment.backEndUrl}${path}`,
      JSON.stringify(body),
      this.httpOptions
    ).pipe(catchError(this.formatErrors));
  }

  delete(path): Observable<any> {
    return this.http.delete(
      `${environment.backEndUrl}${path}`
    ).pipe(catchError(this.formatErrors));
  }
}
