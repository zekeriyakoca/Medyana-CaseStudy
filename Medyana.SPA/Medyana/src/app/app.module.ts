import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutes } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainComponent } from './Main/main.component';
import { SharedModule } from './Shared/shared.module';
import { HomeModule } from './Modules/Home/home.module';
import { CoreModule } from './Core/core.module';
import { RouterModule ,Routes} from '@angular/router';
import { ClinicModule } from './Modules/Clinic/Clinic.module';
import { EquipmentModule } from './Modules/Equipment/Equipment.module';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(AppRoutes),
    BrowserAnimationsModule,
    SharedModule,
    HomeModule,
    CoreModule,
    ClinicModule,
    EquipmentModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
