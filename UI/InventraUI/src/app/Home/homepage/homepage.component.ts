import { Component } from '@angular/core';
import { DatePipe } from '@angular/common';
import { AuthService } from '../../Services/auth.service';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button'
import { MatGridList, MatGridTile, MatGridTileFooterCssMatStyler, MatGridTileHeaderCssMatStyler } from "@angular/material/grid-list";
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatCardHeader, MatCardModule } from "@angular/material/card";

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [DatePipe, MatSidenavModule, MatIconModule, MatButtonModule, MatGridList, MatGridTile,
    MatGridTileHeaderCssMatStyler, MatGridTileFooterCssMatStyler, MatDatepickerModule, MatNativeDateModule, FormsModule, MatFormFieldModule, MatCardHeader, MatCardModule],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent {

  selectedDate = new Date();
  drawer = [{ name: "Dashboard", icon: "dashboard" }, { name: "Customers", icon: "group" },
  { name: "Stock", icon: "inventory_2" }, { name: "Sales/Invoice", icon: "receipt_long" },
  { name: "Due Amount", icon: "payments" }, { name: "Reports", icon: "description" },
  { name: "Businesses", icon: "business" }, { name: "Employees", icon: "badge" },
  { name: "Settings", icon: "settings" }, { name: "LogOut", icon: "logout" },
  ]


  summaryCard = [{ iconname: 'shopping_cart', title: 'Total Sales Today', value: '₹1,20,000', statusIcon: 'arrow_drop_up', statusDetails: '12.5% from yesterday' },
  { iconname: 'account_balance_wallet', title: 'Total Due Amount', value: '₹20,000', statusIcon: 'arrow_drop_up', statusDetails: '8.5% from yesterday' },
  { iconname: 'payments', title: 'Total Recovery Amount', value: '₹80,000', statusIcon: 'arrow_drop_up', statusDetails: '18.5% from yesterday' },
  // { iconname: 'inventory_2', title: 'Total Stock', value: '850 Kg', statusIcon: 'arrow_drop_up', statusDetails: 'Updated Just now' },
  // { iconname: 'groups', title: 'Total Customers', value: '123', statusIcon: 'arrow_drop_up', statusDetails: '5 new customers' },
  { iconname: 'trending_up', title: 'Monthly Profit', value: '₹2,20,000', statusIcon: 'arrow_drop_up', statusDetails: '8.2% from last month' }

  ]

  constructor(private authservice: AuthService) { }

  ngOnInit(): void {

    console.log(this.authservice.decodeToken());
    console.log(this.authservice.isTokenExpired());
  }
  onDateChange(event: any) {
    this.selectedDate = event.value;
  }
}
