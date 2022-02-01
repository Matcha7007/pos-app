import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionWarehouseGuard implements CanActivate {
  constructor(
    private auth: AuthService,
    private route: Router
    ){}
  canActivate(){
    console.log("Check Role Administrator/Warehouse");
    if (this.auth.getRole() === 'Administrator' || this.auth.getRole() === 'Warehouse')
    return true
    else
    {
      this.route.navigate(['/main'])
      return false;
    }
  }
}