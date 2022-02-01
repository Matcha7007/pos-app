import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.scss']
})



export class AlertComponent implements OnInit {

  typeAlert: any = 'success'
  backColor: any;
  color:any ;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {

    if (this.data.id === 'success'){
      this.backColor = '#00a97e';
      this.color = 'white';
    } else if (this.data.id === 'failed'){
      this.backColor = '#cf4436';
      this.color = 'white';
    } else {
      this.backColor = '#da8c10';
      this.color = 'white';
    }


  }

}
