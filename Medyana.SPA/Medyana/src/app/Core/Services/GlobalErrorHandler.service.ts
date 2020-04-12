import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  constructor() { }

  handleError(error) {

    //We need to redirect to error page here.
    console.error(error);
  }

}