import { Component, Input } from '@angular/core';
import { MatCardHeader, MatCardModule } from "@angular/material/card";
import { MatIcon } from "@angular/material/icon";
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatOption } from '@angular/material/core';
import { DatePipe } from '@angular/common';
import { MatDrawerContainer, MatDrawer } from "@angular/material/sidenav";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatCardHeader, MatNativeDateModule, MatDatepickerModule, MatIcon, DatePipe, MatCardModule, MatDrawerContainer, MatDrawer],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  @Input() title:string='';
  @Input() subtitle:string='';
  @Input() userProfileImage:string='...';
  @Input() userName:string='';
  @Input() userRole:string=''
  selectedDate = new Date();
onDateChange($event: Event) {
throw new Error('Method not implemented.');
}



}
