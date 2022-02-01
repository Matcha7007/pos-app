import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogSignoutComponent } from 'src/app/dialogs/dialog-signout/dialog-signout.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Output() public sidenavToggle = new EventEmitter();
  
  isExpanded: boolean = true;
  loggedinUser: any;
  showDialog: boolean = false;

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.loggedIn();
  }

  public onToggleSidenav = () => { 
    this.sidenavToggle.emit();
  }

  // function loggedIn, mengambil username yang sudah disimpan sebelumnya di local storage
  loggedIn() {
    this.loggedinUser = localStorage.getItem('userName');
    return this.loggedinUser;
  }


  openDialog() {
    this.dialog.open(DialogSignoutComponent);
  }

}

