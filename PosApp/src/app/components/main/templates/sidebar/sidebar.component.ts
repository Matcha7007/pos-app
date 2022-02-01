import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { trigger, animate, transition } from '@angular/animations';
import { AuthService } from 'src/app/services/auth.service';
import { AlertService } from 'src/app/services/alert.service';
import { DataService } from 'src/app/services/data.service';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  animations: [
    trigger('popState', [
      transition('show => hide', animate('1s ease-out')),
      transition('hide => show', animate('1s ease-in')),
    ])
  ]
})
export class SidebarComponent implements OnInit {

  @Output() sidenavClose = new EventEmitter();
  
  isExpanded: boolean = true;
  isShow: boolean = false;
  loggedinUser: any;
  initialUser: any;
  userRole: any;
  id: any ;
  items = ['Item 1', 'Item 2', 'Item 3', 'Item 4', 'Item 5'];
  expandedIndex = 0;

  constructor(
    private auth: AuthService,
    private alert: AlertService,
    private data: DataService
  ) { }

  ngOnInit(): void {
    this.loggedinUser = localStorage.getItem('userName');
    this.id = localStorage.getItem('userRole');
    this.initialUser = this.getInitials(this.loggedinUser);
    this.userRole = this.auth.getRole();
  }

  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }
  
  getInitials(name: any){
    const nameArray = name.split(' ');
    let initials = '';
    for (let i = 0; i < nameArray.length; i++) {
      if (i <= 1) {
        initials = initials + nameArray[i][0];
      }
    }
    return initials.toUpperCase();
  }

  get stateName() {
    return this.isExpanded? 'show' : 'hide';
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  show(ids: any) {
    if (this.id == ids) {
      this.id = '';
    }
    else {
      this.id = ids;
    }
  }

  onInfo() {
    this.data.getAllTomat();
    this.alert.alertSuccess('Berhasil Horeee!!!');
  }
}
