import { Component } from '@angular/core';
import { MatDrawerContainer, MatDrawer, MatDrawerContent } from "@angular/material/sidenav";
import { MatIcon } from "@angular/material/icon";
import { Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from "../../Header/header/header.component";

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [MatDrawerContainer, MatDrawer, MatIcon, MatDrawerContent, RouterOutlet, HeaderComponent],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {

    userImage: string = 'https://material.angular.dev/assets/img/examples/shiba1.jpg';
   title:string='Dashboard'
   subtitle:string='Welcome back, Avinash!'
   userRole:string='Admin'
   currentUser:string='Avinash'

 drawer = [{ name: "Dashboard", icon: "dashboard" }, { name: "Customers", icon: "group" },
  { name: "Stock", icon: "inventory_2" }, { name: "Sales/Invoice", icon: "receipt_long" },
  { name: "Due Amount", icon: "payments" }, { name: "Reports", icon: "description" },
  { name: "Businesses", icon: "business" }, { name: "Employees", icon: "badge" },
  { name: "Settings", icon: "settings" }, { name: "LogOut", icon: "logout" },
  ]


  constructor(private router:Router){}

  NavigateSections(path:any){
    path=path.toLowerCase();
    console.log("navigate section path = "+path);
    switch(path)
    {
      case 'dashboard':this.router.navigate(['home']);break;
      case 'sales/invoice':this.router.navigate(['sales']);break;
      case 'due amount':this.router.navigate(['due']);break;
      default:this.router.navigate([path]);break;
    }
    // if(path =='Dashboard')
    // {
    //   this.router.navigate(['home'])
    // }else
    // this.router.navigate([path])
  }

}
