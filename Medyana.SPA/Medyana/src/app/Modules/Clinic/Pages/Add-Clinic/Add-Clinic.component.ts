import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DataService } from 'src/app/Core/Services/data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-Add-Clinic',
  templateUrl: './Add-Clinic.component.html',
  styleUrls: ['./Add-Clinic.component.css']
})
export class AddClinicComponent implements OnInit {

  constructor(public dataService: DataService, public router: Router) { }

  ngOnInit() {

  }

  clinicForm: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required)
  });

  addClinic() {
    let request: ClinicInsertRequest = this.clinicForm.value as ClinicInsertRequest;
    this.dataService.addClinic(request).then(_ => {
      this.router.navigateByUrl("/clinic");
    }).catch(function(e){
      alert("An error occured while creating new clinic. Please try again.")
  });;
  }


}
