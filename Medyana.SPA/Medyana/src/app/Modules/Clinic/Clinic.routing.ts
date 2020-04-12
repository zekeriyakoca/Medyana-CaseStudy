import { Routes } from '@angular/router';
import { ListClinicComponent } from './Pages/List-Clinic/List-Clinic.component';
import { EditClinicComponent } from './Pages/Edit-Clinic/Edit-Clinic.component';
import { AddClinicComponent } from './Pages/Add-Clinic/Add-Clinic.component';
import { ClinicComponent } from './Clinic.component';

export const ClinicRoutes:Routes =[
    { 
        path: '', 
        component: ClinicComponent ,
        children:[
            { 
                path: '', 
                component: ListClinicComponent ,
            },
            { 
                path: 'add', 
                component: AddClinicComponent ,
            },
            { 
                path: 'edit/:id', 
                component: EditClinicComponent ,
            }

        ]
    },

]
