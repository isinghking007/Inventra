import { Routes } from '@angular/router';
import { RegistrationComponent } from './UserManagement/Authentication/registration/registration.component';
import { LoginComponent } from './UserManagement/Authentication/login/login.component';
import {AuthComponent} from './UserManagement/Authentication/auth/auth.component'
import {HomepageComponent} from './Home/homepage/homepage.component'
import { HeaderComponent } from './Shared/Header/header/header.component';
import {CustomersComponent} from './Home/Customers/customers/customers.component'
import {StocksComponent} from './Home/Stocks/stocks/stocks.component'
import {EmployeesComponent} from './Home/Employees/employees/employees.component'
import {SalesComponent} from './Home/Sales/sales/sales.component'
import {DueComponent} from './Home/Due Amount/due/due.component'
import {ReportsComponent} from './Home/Reports/reports/reports.component'
import {BusinessesComponent} from './Home/Businesses/businesses/businesses.component'
import {SettingsComponent} from './Home/Settings/settings/settings.component'
export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
    {

    path:'auth',component:AuthComponent,children:[
        {
            path:'',redirectTo:'register',pathMatch:'full'
        },
        {
            path:'register',component:RegistrationComponent
        },
        {
            path:'login',component:LoginComponent
        }
    ],
   
},
{path:'home',component:HomepageComponent},
{path:'header',component:HeaderComponent},
{path:'customers',component:CustomersComponent},
{path:'stock',component:StocksComponent},
{path:'sales',component:SalesComponent},
{path:'due',component:DueComponent},
{path:'reports',component:ReportsComponent},
{path:'employees',component:EmployeesComponent},
{path:'businesses',component:BusinessesComponent},
{path:'settings',component:SettingsComponent}
];
