

import { Routes } from '@angular/router';
import { MainComponent } from './Main/main.component';
import { NotFoundComponent } from './Core/Pages/NotFound/NotFound.component';
import { HomeComponent } from './Modules/Home/pages/home/home.component';


export const AppRoutes: Routes = [
   {
      path: '',
      redirectTo: '/home',
      pathMatch: 'full'
   },
   {
      path: '',
      component: MainComponent,
      children: [
         {
            path: 'home',
            component: HomeComponent
         },
         {
            path: 'clinic',
            loadChildren: './Modules/Clinic/Clinic.module#ClinicModule'
         },
         {
            path: 'equipment',
            loadChildren: './Modules/Equipment/Equipment.module#EquipmentModule'
         },

      ]
   },
   {
      path: '**',
      redirectTo: 'not-found'
   },
   {
    path: 'not-found',
    component: NotFoundComponent
 },
   
]
