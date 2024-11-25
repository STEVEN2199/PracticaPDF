import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';

import { ResetPasswordComponent } from './pages/reset-password/reset-password.component';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { RouterLink } from '@angular/router';
import { LogoComponent } from './components/logo/logo.component';
import { InputTextModule } from 'primeng/inputtext';
import { ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';

@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent,
    RegisterComponent,
    ResetPasswordComponent,
    LogoComponent,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    RouterLink,
    InputTextModule,
    ReactiveFormsModule,
    ButtonModule,
    RippleModule,
  ],
})
export class AuthModule {}
