import { Component, OnInit, signal } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';
import {ChangeDetectionStrategy} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import {MatInputModule} from '@angular/material/input'
import {MatIconModule} from '@angular/material/icon'
import { RouterOutlet } from '@angular/router';

export interface Tile {
  color: string;
  cols: number;
  rows: number;
  text: string;
  image:any;
}

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [RouterOutlet,MatGridListModule,MatCardModule,MatButtonModule,ReactiveFormsModule,MatInputModule,MatIconModule],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent implements OnInit{

  tiles: Tile[] = [
    {text: 'One', cols: 2, rows: 1, color: 'lightblue',image:"assets/Images/reg_background.png"},
    {text: 'Four', cols: 2, rows: 1, color: '#DDBDF1',image:""},
  ];
 
  RegistrationForm!:FormGroup

  ngOnInit(){
    this.RegistrationForm=new FormGroup({
    name : new FormControl('',[Validators.required,Validators.minLength(4),Validators.maxLength(15)]),
    // email: new FormControl(''),
    phone:new FormControl('',[    Validators.required, 
      Validators.pattern(/^\d{10}$/),  // Exactly 10 digits
      Validators.minLength(10),
      Validators.maxLength(10)
   ]),
   address:new FormControl('',[Validators.required,Validators.minLength(3)]),
   password:new FormControl('',[Validators.required,Validators.minLength(3)])
  })
  }
   hide = signal(true);
  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }
  submitForm()
  {
    console.log("this form has been submitted",this.RegistrationForm.value)
  }
  login()
  {
    console.log("logged In button clicked")
  }

}
