import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './modules/home/home.component';
import { AddPaymentComponent } from './modules/master/add-payment/add-payment.component';
import { AddUnitComponent } from './modules/master/add-unit/add-unit.component';
import { PurchasingComponent } from './modules/transaction/purchasing/purchasing.component';
import { SellingComponent } from './modules/transaction/selling/selling.component';
import { CommonModule } from '@angular/common';
import { PermissionAdministratorGuard } from 'src/app/services/guards/permission-administrator.guard';
import { PermissionCashierGuard } from 'src/app/services/guards/permission-cashier.guard';
import { PermissionAdminGuard } from 'src/app/services/guards/permission-admin.guard';
import { DataComponent } from './modules/master/data/data.component';
import { CustomerComponent } from './modules/master/customer/customer.component';

const routes: Routes = [
  { path: '', 
    component: DashboardComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'selling', component: SellingComponent, 
        canActivate: [PermissionCashierGuard],
        data: {
          accessRole: ['Cashier']
        } },
      { path: 'purchasing', component: PurchasingComponent,
        canActivate: [PermissionCashierGuard],
        data: {
          accessRole: ['Cashier']
        } },
      { path: 'add-payment', component: AddPaymentComponent,
        canActivate: [PermissionAdminGuard],
        data: {
          accessRole: ['Admin']
        } },
      { path: 'add-unit', component: AddUnitComponent,
        canActivate: [PermissionAdminGuard],
        data: {
          accessRole: ['Admin']
        } },
      { path: 'data', component: DataComponent,
        canActivate: [PermissionAdminGuard],
        data: {
          accessRole: ['Admin']
        } },
      { path: 'customer', component: CustomerComponent,
        canActivate: [PermissionAdminGuard],
        data: {
          accessRole: ['Admin']
        } },
      { path: '', redirectTo: '/main/home', pathMatch: 'full' },
      { path: '**', redirectTo: '/main/home', pathMatch: 'full' },
    ]
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }
