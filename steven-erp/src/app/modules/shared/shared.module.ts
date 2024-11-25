import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { CustomInputComponent } from './components/custom-input/custom-input.component';

@NgModule({
  declarations: [NavbarComponent, SidebarComponent, CustomInputComponent],
  imports: [CommonModule],
  exports: [NavbarComponent, SidebarComponent, CustomInputComponent],
})
export class SharedModule {}
