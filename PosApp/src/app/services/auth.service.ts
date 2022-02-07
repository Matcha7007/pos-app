import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserForLogin, UserForRegister } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.baseUrl;

  constructor(
    private http: HttpClient
  ) { }

  isLoggedIn() {
    return !!localStorage.getItem('token');
  }

  getRole() {
    var id = localStorage.getItem('userRole');
    var role = '';
    if ( id == '1') {
      role = 'Administrator';
    } else if ( id == '2') {
      role = 'Admin';
    } else if ( id == '3') {
      role = 'Warehouse';
    } else {
      role = 'Cashier'
    }
    return role;
  }

  authUser(user: UserForLogin) {
    return this.http.post(this.baseUrl + 'User/signin', user);
  }

  registerUser(user: UserForRegister) {
    return this.http.post(this.baseUrl + 'User/signup', user);
  }

}
