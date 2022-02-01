import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionCashierGuard implements CanActivate {
  constructor(
    private auth: AuthService,
    private route: Router
    ){}
  canActivate() {
    console.log("Check Role Administrator/Cashier " + this.auth.getRole());
    if (this.auth.getRole() === 'Administrator' || this.auth.getRole() === 'Cashier')
    return true
    else
    {
      this.route.navigate(['/main'])
      return false;
    }
  }
}

