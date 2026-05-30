import { Component } from '@angular/core';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent {

  constructor(private authservice:AuthService){}

  ngOnInit():void{

    console.log(this.authservice.decodeToken());
    console.log(this.authservice.isTokenExpired());
  }

}
