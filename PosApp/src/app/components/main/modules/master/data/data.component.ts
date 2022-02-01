import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DataService } from 'src/app/services/data.service';
import { DataTomat } from '../../../interfaces/data';
import tomat from 'src/app/data/data_tomat.json'

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.scss']
})
export class DataComponent implements OnInit, AfterViewInit {

  constructor(
    private data: DataService
  ) { }

  public dataList: DataTomat[] = tomat;
  listData!: MatTableDataSource<DataTomat>;
  displayedColumns: string[] = ['id', 'kode_provinsi', 'nama_provinsi', 'kode_kabupaten_kota', 'nama_kabupaten_kota', 'produksi_tomat', 'satuan', 'tahun', 'actions'];
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  searchKey!: string;

  ngAfterViewInit() {
    this.listData.paginator = this.paginator;
    this.listData.sort = this.sort;
  }

  ngOnInit(): void {
    this.listData = new MatTableDataSource<DataTomat>(this.dataList);
    this.listData.filterPredicate = (data, filter) => {
      return this.displayedColumns.some(ele => {
        return ele != 'actions' && data[ele as keyof DataTomat].toString().toLowerCase().indexOf(filter) != -1;
      });
    };
    //console.log('list ' + this.dataList)
  }

  onSearchClear() {
    this.searchKey = "";
    this.applyFilter();
  }

  applyFilter() {
    this.listData.filter = this.searchKey.trim().toLowerCase();
  }
}
