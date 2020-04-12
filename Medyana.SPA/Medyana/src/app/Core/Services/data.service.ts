import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable, of } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { error } from 'util';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(public apiService: ApiService) {

  }

  getClinic(clinicId:number): Promise<Clinic> {
    return this.apiService.get(`api/clinic/${clinicId}`).pipe(tap(result => {
      
    }
    )).toPromise();
  }
  getClinics(request:PaginationRequest): Promise<PaginatedList<Clinic>> {
    return this.apiService.post("api/clinic",request).pipe(tap(result => {
      
    }
    )).toPromise();
  }
  addClinic(request:ClinicInsertRequest): Promise<boolean> {
    return this.apiService.put("api/clinic",request).pipe(tap(result => {
      
    }
    )).toPromise();
  }

  updateClinic(request:ClinicUpdateRequest): Promise<boolean> {
    return this.apiService.patch("api/clinic",request).pipe(tap(result => {
      
    }
    )).toPromise();
  }

  deleteClinic(clinicId: number): Promise<boolean> {
    if (!clinicId || clinicId < 1) {
      return of(false).toPromise();
    }
    return this.apiService.delete(`api/clinic/${clinicId}`).pipe(
      tap(result => {
        
      },
        map(_ => true)
      )
    ).toPromise();
  }

  getEquipment(equipmentId:number): Promise<Equipment> {
    return this.apiService.get(`api/equipment/${equipmentId}`).pipe(tap(result => {
      
    }
    )).toPromise();
  }
  getEquipments(request:PaginationRequest): Promise<PaginatedList<Equipment>> {
    return this.apiService.post("api/equipment",request).pipe(tap(result => {
      
    }
    )).toPromise();
  }
  addEquipment(request:EquipmentInsertRequest): Promise<boolean> {
    return this.apiService.put("api/equipment",request).pipe(tap(result => {
      
    }
    )).toPromise();
  }

  updateEquipment(request:EquipmentUpdateRequest): Promise<boolean> {
    return this.apiService.patch("api/equipment",request).pipe(tap(result => {
      
    }
    )).toPromise();
  }

  deleteEquipment(equipmentId: number): Promise<boolean> {
    if (!equipmentId || equipmentId < 1) {
      return of(false).toPromise();
    }
    return this.apiService.delete(`api/equipment/${equipmentId}`).pipe(
      tap(result => {
        
      },
        map(_ => true)
      )
    ).toPromise();
  }

}
