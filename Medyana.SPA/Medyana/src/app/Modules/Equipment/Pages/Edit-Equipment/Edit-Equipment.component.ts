import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/Core/Services/data.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-Edit-Equipment',
  templateUrl: './Edit-Equipment.component.html',
  styleUrls: ['./Edit-Equipment.component.css']
})
export class EditEquipmentComponent implements OnInit {

  equipmentId: number;
  clinicId: number;
  equipment: BehaviorSubject<Equipment> = new BehaviorSubject<Equipment>(null);
  constructor(public dataService: DataService, public router: Router, public route: ActivatedRoute) { }

  ngOnInit() {
    this.equipmentId = +this.route.snapshot.paramMap.get("id");
    this.clinicId = +this.route.snapshot.paramMap.get("clinicId");
    this.fetchEquipment(this.equipmentId);
  }

  fetchEquipment(equipmentId: number) {
    this.dataService.getEquipment(equipmentId).then((equipment: Equipment) => {
      this.equipmentForm.setValue({clinicId:equipment.clinicId , id: equipment.id, name: equipment.name, price: equipment.price, quantity:equipment.quantity, usageRate: equipment.usageRate });
    })
  }

  equipmentForm: FormGroup = new FormGroup({
    clinicId: new FormControl('', Validators.required),
    id: new FormControl('', Validators.required),
    name: new FormControl('', Validators.required),
    price: new FormControl('', [ Validators.required, Validators.min(0.01)]),
    quantity: new FormControl('',[ Validators.required, Validators.min(1)]),
    usageRate: new FormControl('',[ Validators.min(1), Validators.max(100)]),
  });

  editEquipment() {
    let request: EquipmentUpdateRequest = this.equipmentForm.value as EquipmentUpdateRequest;
    this.dataService.updateEquipment(request).then(_ => {
      this.router.navigate(['/equipment',{clinicId:this.clinicId}])
    }).catch(function (e) {
      alert("An error occured while updating new clinic. Please try again.")
    });;
  }

}
