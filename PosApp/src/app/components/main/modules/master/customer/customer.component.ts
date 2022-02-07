import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Customer } from 'src/app/models/customer';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public dataList!: Customer[];
  listData!: MatTableDataSource<Customer>;
  displayedColumns: string[] = ['no', 'name', 'address', 'phone', 'actions'];
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  searchKey!: string;
  constructor(
    private custService: CustomerService
  ) { }

  ngAfterViewInit() {

  }

  ngOnInit(): void {
    this.custService.getAllCustomers().subscribe( data => {
      this.listData = new MatTableDataSource<Customer>(data);

      this.listData.sort = this.sort;
      this.listData.paginator = this.paginator;
      this.listData.filterPredicate = (data, filter) => {
        console.log(data + " | " + filter);
        return this.displayedColumns.some(ele => {
          return ele != 'actions' && data[ele as keyof Customer].toString().toLowerCase().indexOf(filter) != -1;
        });
      };

      console.log(data);
    });
  }

  onSearchClear() {
    this.searchKey = "";
    this.applyFilter();
  }

  applyFilter() {
    this.listData.filter = this.searchKey.trim().toLowerCase();
  }

}
