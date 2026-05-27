import { Routes } from '@angular/router';
import { RegistrationComponent } from './UserManagement/Authentication/registration/registration.component';
import { LoginComponent } from './UserManagement/Authentication/login/login.component';
import {AuthComponent} from './UserManagement/Authentication/auth/auth.component'
import {HomepageComponent} from './Home/homepage/homepage.component'
export const routes: Routes = [
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
{path:'home',component:HomepageComponent}
];
