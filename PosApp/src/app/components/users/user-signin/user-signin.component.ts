import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForLogin } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-signin',
  templateUrl: './user-signin.component.html',
  styleUrls: ['./user-signin.component.scss']
})
export class UserSigninComponent implements OnInit {

  //hide password
  hide = true;

  // inject service dan router
  constructor(
    private auth: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  // function login, data yang diambil dari form login dikirim ke api/User/login
  // untuk di verifikasi lalu mengembalikan return ke service angular
  onLogin(loginForm: NgForm) {
    console.log(loginForm.value);
    //memanggil fungsi service authUser
    this.auth.authUser(loginForm.value).subscribe(
      (response: UserForLogin) => {
        console.log(response);
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token); //menyimpan token dari api ke lokal storage
          localStorage.setItem('userName', user.userName); //menyimpan userName dari api ke lokal storage
          localStorage.setItem('userRole', user.userRole);
          this.router.navigate(['/main']); //mendirect ke halaman main
        }
      }
    )
  }

}
