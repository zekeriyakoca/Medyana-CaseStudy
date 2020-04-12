import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddClinicComponent } from './Pages/Add-Clinic/Add-Clinic.component';
import { EditClinicComponent } from './Pages/Edit-Clinic/Edit-Clinic.component';
import { ListClinicComponent } from './Pages/List-Clinic/List-Clinic.component';
import { RouterModule } from '@angular/router';
import { ClinicRoutes } from './Clinic.routing'
import { ClinicComponent } from './Clinic.component';
import { SharedModule } from 'src/app/Shared/shared.module';
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ClinicRoutes),
    SharedModule
  ],
  declarations: [ClinicComponent, AddClinicComponent, EditClinicComponent, ListClinicComponent]
})
export class ClinicModule { }
