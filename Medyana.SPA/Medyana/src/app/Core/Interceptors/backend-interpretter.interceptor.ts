import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class BackendInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    // const headersConfig = request.headers.set('Content-Type','application/json').set('Accept', 'application/json')
    // .set('credentials', 'same-origin').set('withCredentials', 'true')
    // const headersConfig = {
    //   'Content-Type': 'application/json',
    //   'Accept': 'application/json',
    //   'credentials': 'same-origin',
    //   'withCredentials' : 'true'
    // };
    // var newRequest = request.clone({headers :headersConfig});

    return next.handle(request);
  }
}
