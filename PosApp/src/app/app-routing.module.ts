import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserSigninComponent } from './components/users/user-signin/user-signin.component';
import { UserSignupComponent } from './components/users/user-signup/user-signup.component';
import { AuthenticationGuard } from './services/guards/authentication.guard';

const routes: Routes = [
  { path: 'signin', component: UserSigninComponent },
  { path: 'signup', component: UserSignupComponent },
  { path: '', redirectTo: '/signin', pathMatch: 'full' },
  { path: 'main',
    loadChildren:() =>
      import('./components/main/main.module').then(m => m.MainModule),
      canActivate: [AuthenticationGuard] 
    },
  { path: '**', redirectTo: '/signin', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
