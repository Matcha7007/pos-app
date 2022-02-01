import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './core/material.module';
import { UserSigninComponent } from './components/users/user-signin/user-signin.component';
import { UserSignupComponent } from './components/users/user-signup/user-signup.component';
import { AuthService } from './services/auth.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DialogSignoutComponent } from './dialogs/dialog-signout/dialog-signout.component';
import { PopUpSuccessComponent } from './dialogs/pop-up-success/pop-up-success.component';
import { PopUpFailedComponent } from './dialogs/pop-up-failed/pop-up-failed.component';
import { PopUpWarningComponent } from './dialogs/pop-up-warning/pop-up-warning.component';
import { AlertComponent } from './dialogs/alert/alert.component';
import { DataService } from './services/data.service';

@NgModule({
  declarations: [
    AppComponent,
    UserSigninComponent,
    UserSignupComponent,
    DialogSignoutComponent,
    PopUpSuccessComponent,
    PopUpFailedComponent,
    PopUpWarningComponent,
    AlertComponent
  ],
  entryComponents: [
    DialogSignoutComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthService,
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
