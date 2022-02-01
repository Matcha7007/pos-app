import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionAdministratorGuard implements CanActivate {
  constructor(
    private auth: AuthService,
    private route: Router
  ){}
  canActivate() {
    if (this.auth.getRole() === 'Administrator')
    return true;
    else
    {
      this.route.navigate(['/main'])
      alert('You have not accessed');
      return false;
    }
  }
}

