import { Component, OnInit, ViewChild } from '@angular/core';
import { BehaviorSubject, Subscription } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DataService } from 'src/app/Core/Services/data.service';
import { debounceTime } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-List-Equipment',
  templateUrl: './List-Equipment.component.html',
  styleUrls: ['./List-Equipment.component.css']
})
export class ListEquipmentComponent implements OnInit {

  displayedColumns: string[] = ['clinicName', 'id', 'name', 'supplyDate', 'quantity', 'usageRate', 'price', 'actions'];
  dataSource$: BehaviorSubject<MatTableDataSource<Equipment>> = new BehaviorSubject<MatTableDataSource<Equipment>>(new MatTableDataSource([]));
  matDataSource = new MatTableDataSource<Equipment>();
  filterChange: BehaviorSubject<string> = new BehaviorSubject<string>("");
  subscriptions: Subscription[] = [];
  hasPrev: boolean = false;
  hasNext: boolean = false;
  currentPage: number = 0;
  clinicId:number;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(public dataService: DataService, public route: ActivatedRoute) {
    // Assign the data to the data source for the table to render
    this.dataSource$;
  }

  ngOnInit() {
    this.clinicId = +this.route.snapshot.paramMap.get('clinicId');
    this.matDataSource.paginator = this.paginator;
    this.matDataSource.sort = this.sort;
    this.subscriptions.push(
      this.filterChange.pipe(debounceTime(500)).subscribe(filterValue => {
        let request: PaginationRequest = { page: 0, pageItemCount: this.matDataSource.paginator.pageSize, searchText: filterValue, clinicId: this.clinicId };
        this.fetchEquipments(request);
      }
      )
    );
  }

  applyFilter(filterValue: string) {
    this.filterChange.next(filterValue);
  }

  sortChanged({ active, direction }) {
    let request: PaginationRequest = { page: 0, pageItemCount: this.matDataSource.paginator.pageSize, isAscending: direction == 'asc', column: active };
    this.fetchEquipments(request);

  }

  deleteEquipment(equipmentId: number) {
    this.dataService.deleteEquipment(equipmentId).then(result => {
      if (result) {
        this.toPage(0);
        alert("equipment deleted");
      }
      else
        alert("Error occured while deleting equipment");
    });
  }

  fetchEquipments(request: PaginationRequest) {
    this.dataService.getEquipments(request).then(equipment => {
      this.hasNext = equipment.hasNext;
      this.hasPrev = equipment.hasPrev;
      this.currentPage = equipment.page;
      this.matDataSource.data = equipment.items;
      this.dataSource$.next(this.matDataSource);

    });
  }

  pageChanged({ pageIndex, pageSize, length, ...params }) {
    let request: PaginationRequest = { page: pageIndex, pageItemCount: pageSize };
    this.fetchEquipments(request);
  }
  toPage(page: number): void {
    let request: PaginationRequest = { page: page, pageItemCount: this.matDataSource.paginator.pageSize, clinicId: this.clinicId };
    this.fetchEquipments(request);
  }


  ngOnDestroy(): void {
    this.subscriptions.map(s => s.unsubscribe());
  }

}
