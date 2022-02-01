import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AlertComponent } from '../dialogs/alert/alert.component';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  timeout = 1000;
  constructor(
    private dialog: MatDialog
  ) { }

  alertSuccess(msg: any): void {
    const timeout = this.timeout;
    const alert =  this.dialog.open(AlertComponent, {
      width: '350px',
      height: '50px',
      disableClose: false,
      panelClass: 'custom-modalbox',
      position: {
        bottom: '10px',
        right: '10px'
      },
      data: {
        message: msg,
        id: 'success'
      },
    });
    alert.afterOpened().subscribe(_ => {
      setTimeout(() => {
        alert.close();
     }, timeout)
    })
  }

  alertFailed(msg: any): void {
    const timeout = this.timeout;
    const alert =  this.dialog.open(AlertComponent, {
      width: '350px',
      height: '50px',
      disableClose: false,
      panelClass: 'custom-modalbox',
      position: {
        bottom: '10px',
        right: '10px'
      },
      data: {
        message: msg,
        id: 'failed'
      },
    });
    alert.afterOpened().subscribe(_ => {
      setTimeout(() => {
        alert.close();
     }, timeout)
    })
  }

  alertWarn(msg: any): void {
    const timeout = this.timeout;
    const alert =  this.dialog.open(AlertComponent, {
      width: '350px',
      height: '50px',
      disableClose: false,
      panelClass: 'custom-modalbox',
      position: {
        bottom: '10px',
        right: '10px'
      },
      data: {
        message: msg,
        id: 'warn'
      },
    });
    alert.afterOpened().subscribe(_ => {
      setTimeout(() => {
        alert.close();
     }, timeout)
    })
  }

}
