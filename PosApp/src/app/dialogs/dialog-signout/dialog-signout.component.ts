import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dialog-signout',
  templateUrl: './dialog-signout.component.html',
  styleUrls: ['./dialog-signout.component.scss']
})
export class DialogSignoutComponent implements OnInit {

  user: any;
  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
    this.user = localStorage.getItem('userName');
  }

  // function loggedOut, menghapus token dan username yang sudah disimpan
  // di localstorage pada saat proses login
  loggedOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('userName');
    localStorage.removeItem('userRole');
    this.router.navigate(['/']);
  }

}
