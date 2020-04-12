import { Component, OnInit } from "@angular/core";
import { Title, Meta } from "@angular/platform-browser";
import { NavigationEnd, Router } from "@angular/router";
import { ModalService } from '../Core/Services/modal.service';


@Component({
  selector: "app-main",
  templateUrl: "./main.component.html",
  styleUrls: ["./main.component.scss"]
})
export class MainComponent implements OnInit {
  currentUrl: string;
  appVersion: string;

  constructor(
    public router: Router,
    public modalService:ModalService,
    meta: Meta,
    title: Title
  ) {
    title.setTitle("Medyana");
    this.appVersion = "1.1";

    meta.addTags([
      { name: "author", content: "" },
      { name: "keywords", content: " " },
      { name: "description", content: "" }
    ]);
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.currentUrl = event.url;
      }
    });
  }

  ngOnInit(): void {


  }
  removeModal(){
    this.modalService.destroy();
  }
  
}
