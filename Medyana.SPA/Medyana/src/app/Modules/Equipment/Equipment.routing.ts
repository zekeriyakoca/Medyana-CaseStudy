import { Routes } from '@angular/router';
import { ListEquipmentComponent } from './Pages/List-Equipment/List-Equipment.component';
import { EditEquipmentComponent } from './Pages/Edit-Equipment/Edit-Equipment.component';
import { AddEquipmentComponent } from './Pages/Add-Equipment/Add-Equipment.component';
import { EquipmentComponent } from './Equipment.component';

export const EquipmentRoutes:Routes =[
    { 
        path: '', 
        component: EquipmentComponent ,
        children:[
            { 
                path: '', 
                component: ListEquipmentComponent ,
            },
            { 
                path: 'add', 
                component: AddEquipmentComponent ,
            },
            { 
                path: 'edit', 
                component: EditEquipmentComponent ,
            }

        ]
    },

]
