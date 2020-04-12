import { Injectable } from "@angular/core";
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: "root"
})
export class CoreService {

  private subscriptions: Subscription[] = [];

  constructor() {}


  ngOnDestroy(): void {
    this.subscriptions.forEach(item => {
      item.unsubscribe();
    });
  }
}
