import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionAdminGuard implements CanActivate {
  constructor(
    private auth: AuthService,
    private route: Router
    ){}
  canActivate() {
    console.log("Check Role Administrator/Admin");
    if (this.auth.getRole() === 'Administrator' || this.auth.getRole() === 'Admin')
    return true;
    else 
    {
      this.route.navigate(['/main'])
      return false;
    }

  } 
}

