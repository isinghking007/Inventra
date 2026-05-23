import { Routes } from '@angular/router';
import { RegistrationComponent } from './UserManagement/Authentication/registration/registration.component';
import { LoginComponent } from './UserManagement/Authentication/login/login.component';
import {AuthComponent} from './UserManagement/Authentication/auth/auth.component'
export const routes: Routes = [
{
    path:'auth',children:[
        {
            path:'register',component:RegistrationComponent
        },
        {
            path:'login',component:LoginComponent
        }
    ],component:AuthComponent
}
];
