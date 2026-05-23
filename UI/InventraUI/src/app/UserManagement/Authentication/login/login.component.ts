import { Component, OnInit, signal } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';
import {ChangeDetectionStrategy} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import {MatInputModule} from '@angular/material/input'
import {MatIconModule} from '@angular/material/icon'
import { Router } from '@angular/router';

export interface Tile {
  color: string;
  cols: number;
  rows: number;
  text: string;
  image:any;
}

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatGridListModule,MatCardModule,MatButtonModule,ReactiveFormsModule,MatInputModule,MatIconModule,MatFormFieldModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  RegistrationForm!:FormGroup
    constructor(private router:Router){}
  
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
    register()
  {
    console.log("register  button clicked")
    this.router.navigate(['/auth/register']);
  }
}
