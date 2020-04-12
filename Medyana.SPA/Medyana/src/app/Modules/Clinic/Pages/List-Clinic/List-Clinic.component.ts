import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DataService } from 'src/app/Core/Services/data.service';
import { BehaviorSubject, Subject, Subscription } from 'rxjs';
import { error } from 'util';
import { debounce, debounceTime, filter } from 'rxjs/operators';

@Component({
  selector: 'app-List-Clinic',
  templateUrl: './List-Clinic.component.html',
  styleUrls: ['./List-Clinic.component.css']
})
export class ListClinicComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'actions'];
  dataSource$: BehaviorSubject<MatTableDataSource<Clinic>> = new BehaviorSubject<MatTableDataSource<Clinic>>(new MatTableDataSource([]));
  dataSource: MatTableDataSource<Clinic>;
  matDataSource = new MatTableDataSource<Clinic>();
  filterChange: BehaviorSubject<string> = new BehaviorSubject<string>("");
  subscriptions: Subscription[] = [];
  hasPrev:boolean = false;
  hasNext:boolean = false;
  currentPage:number = 0;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(public dataService: DataService) {
    // Assign the data to the data source for the table to render
    this.dataSource$;
  }

  ngOnInit() {
    this.matDataSource.paginator = this.paginator;
    this.matDataSource.sort = this.sort;
    // this.fetchClinics({ pageItemCount: 10, page: 0 } as PaginationRequest);
    this.subscriptions.push(
      this.filterChange.pipe(debounceTime(500)).subscribe(filterValue => {
        let request: PaginationRequest = { page: 0, pageItemCount: this.matDataSource.paginator.pageSize, searchText: filterValue };
        this.fetchClinics(request);
      }
      )
    );
  }

  applyFilter(filterValue: string) {
    this.filterChange.next(filterValue);
  }
  
  sortChanged({active,direction}){
    let request: PaginationRequest = { page:0, pageItemCount: this.matDataSource.paginator.pageSize , isAscending: direction=='asc',column:active};
    this.fetchClinics(request);

  }

  deleteClinic(clinicId: number) {
    this.dataService.deleteClinic(clinicId).then(result => {
      if (result)
      {
        this.toPage(0);
        alert("clinic deleted");
      }
      else
        alert("Error occured while deleting clinic");
    });
  }

  fetchClinics(request: PaginationRequest) {
    this.dataService.getClinics(request).then(clinics => {
      this.hasNext = clinics.hasNext;
      this.hasPrev = clinics.hasPrev;
      this.currentPage = clinics.page;
      this.matDataSource.data = clinics.items;
      this.dataSource$.next(this.matDataSource);

    });
  }

  pageChanged({ pageIndex, pageSize, length, ...params }) {
    let request: PaginationRequest = { page: pageIndex, pageItemCount: pageSize };
    this.fetchClinics(request);
  }
  toPage(page:number): void {
    let request: PaginationRequest = { page:page, pageItemCount: this.matDataSource.paginator.pageSize };
    this.fetchClinics(request);
  }
 

  ngOnDestroy(): void {
    this.subscriptions.map(s => s.unsubscribe());
  }

}

/** Builds and returns a new User. */

