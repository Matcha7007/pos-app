import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { HeaderComponent } from './templates/header/header.component';
import { FooterComponent } from './templates/footer/footer.component';
import { SidebarComponent } from './templates/sidebar/sidebar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './modules/home/home.component';
import { MaterialModule } from 'src/app/core/material.module';
import { AddUnitComponent } from './modules/master/add-unit/add-unit.component';
import { AddPaymentComponent } from './modules/master/add-payment/add-payment.component';
import { SellingComponent } from './modules/transaction/selling/selling.component';
import { PurchasingComponent } from './modules/transaction/purchasing/purchasing.component';
import { DataComponent } from './modules/master/data/data.component';
import { FormsModule } from '@angular/forms';
import { CustomerComponent } from './modules/master/customer/customer.component';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    DashboardComponent,
    HomeComponent,
    AddUnitComponent,
    AddPaymentComponent,
    SellingComponent,
    PurchasingComponent,
    DataComponent,
    CustomerComponent
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
    MaterialModule,
    FormsModule
  ]
})
export class MainModule { }
