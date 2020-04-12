import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/Core/Services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-Edit-Clinic',
  templateUrl: './Edit-Clinic.component.html',
  styleUrls: ['./Edit-Clinic.component.css']
})
export class EditClinicComponent implements OnInit {
  clinicId: number;
  clinic: BehaviorSubject<Clinic> = new BehaviorSubject<Clinic>(null);
  constructor(public dataService: DataService, public router: Router, public route: ActivatedRoute) { }

  ngOnInit() {
    this.clinicId = +this.route.snapshot.paramMap.get("id");
    this.fetchClinic(this.clinicId);
  }

  fetchClinic(clinicId:number) {
    this.dataService.getClinic(clinicId).then((clinic:Clinic) => {
      this.clinicForm.setValue({id:clinic.id,name:clinic.name});
      // this.clinic.next(clinic);
    })
  }

  clinicForm: FormGroup = new FormGroup({
    id: new FormControl('', Validators.required),
    name: new FormControl('', Validators.required)
  });

  editClinic() {
    let request: ClinicUpdateRequest = this.clinicForm.value as ClinicUpdateRequest;
    this.dataService.updateClinic(request).then(_ => {
      this.router.navigateByUrl("/clinic");
    }).catch(function (e) {
      alert("An error occured while updating new clinic. Please try again.")
    });;
  }

}
