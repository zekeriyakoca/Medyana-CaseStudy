import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentComponent } from './Equipment.component';
import { EquipmentRoutes } from './Equipment.routing';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/Shared/shared.module';
import { AddEquipmentComponent } from './Pages/Add-Equipment/Add-Equipment.component';
import { EditEquipmentComponent } from './Pages/Edit-Equipment/Edit-Equipment.component';
import { ListEquipmentComponent } from './Pages/List-Equipment/List-Equipment.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(EquipmentRoutes),
    SharedModule
  ],
  declarations: [EquipmentComponent,AddEquipmentComponent,EditEquipmentComponent,ListEquipmentComponent]
})
export class EquipmentModule { }
