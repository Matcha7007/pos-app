import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { DataTomat } from '../components/main/interfaces/data';
import tomat from '../data/data_tomat.json'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(
    private http: HttpClient
  ) { }

    public getAllTomat() {
      let dataTomat: DataTomat[] = tomat;
      //console.log(dataTomat)
      return dataTomat;
    }
}
