import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/Core/Services/data.service';
import { Router, ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-Add-Equipment',
  templateUrl: './Add-Equipment.component.html',
  styleUrls: ['./Add-Equipment.component.css']
})
export class AddEquipmentComponent implements OnInit {
clinicId:number;
 
  constructor(public dataService: DataService, public router: Router, public route:ActivatedRoute) {
    this.clinicId = +this.route.snapshot.paramMap.get("clinicId");
    this.equipmentForm.value.clinicId = this.clinicId;
    this.equipmentForm.setValue(this.equipmentForm.value);
   }

  ngOnInit() {

  }

  equipmentForm: FormGroup = new FormGroup({
    clinicId: new FormControl(this.clinicId, Validators.required),
    name: new FormControl('', Validators.required),
    price: new FormControl('', [ Validators.required, Validators.min(0.01)]),
    quantity: new FormControl('',[ Validators.required, Validators.min(1)]),
    usageRate: new FormControl('',[ Validators.min(1), Validators.max(100)]),
  });

  addEquipment() {
    let request: EquipmentInsertRequest = this.equipmentForm.value as EquipmentInsertRequest;
    this.dataService.addEquipment(request).then(_ => {
      this.router.navigate(["/equipment",{clinicId:this.clinicId}]);
    }).catch(function(e){
      alert("An error occured while creating new equipment. Please try again.")
  });;
  }
}
