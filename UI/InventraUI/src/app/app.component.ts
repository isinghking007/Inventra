import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { RegistrationComponent } from './UserManagement/Authentication/registration/registration.component';
import { AuthService } from './Services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RegistrationComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'InventraUI';

  constructor(private authService:AuthService,private router:Router){}
  ngOnInit():void{

  
    if(this.authService.isTokenExpired())
    {
      alert('Session Expired, Login again')
      this.authService.logOut();
      this.router.navigate(['auth/login'])
    }

  }
}
