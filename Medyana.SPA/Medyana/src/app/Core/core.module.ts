import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AppHeaderComponent } from "./Layout/app-header/app-header.component";
import { AppFooterComponent } from "./Layout/app-footer/app-footer.component";
import { ApiService } from './Services/api.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BackendInterceptor } from './Interceptors/backend-interpretter.interceptor';
import { CoreService } from './Services/core.service';
import { NotFoundComponent } from './Pages/NotFound/NotFound.component';
import { DomService } from './Services/dom.service';
import { ModalService } from './Services/modal.service';
import { SharedModule } from '../Shared/shared.module';


@NgModule({
  declarations: [AppHeaderComponent, AppFooterComponent, NotFoundComponent],
  imports: [CommonModule, HttpClientModule, SharedModule],
  exports: [AppHeaderComponent, AppFooterComponent, NotFoundComponent],
  providers: [ApiService,  CoreService,  DomService, ModalService, 
    { provide: HTTP_INTERCEPTORS, useClass: BackendInterceptor, multi: true }
  ]
})
export class CoreModule { }
