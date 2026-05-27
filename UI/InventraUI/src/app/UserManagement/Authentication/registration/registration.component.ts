import { Component, inject, OnInit, signal } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';
import {ChangeDetectionStrategy} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import {MatInputModule} from '@angular/material/input'
import {MatIconModule} from '@angular/material/icon'
import { Router } from '@angular/router';
import { APIServiceService } from '../../../Services/apiservice.service';
import { SuccesspopupComponent } from '../../../Shared/SuccessPopup/successpopup/successpopup.component';
import { MatDialog } from '@angular/material/dialog';

export interface Tile {
  color: string;
  cols: number;
  rows: number;
  text: string;
  image:any;
}

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [MatGridListModule,MatCardModule,MatButtonModule,ReactiveFormsModule,MatInputModule,MatIconModule,MatFormFieldModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'

})

export class RegistrationComponent implements OnInit {

  RegistrationForm!:FormGroup
 private dialog = inject(MatDialog);
  constructor(private router:Router,private service:APIServiceService){}

  ngOnInit(){
    this.RegistrationForm=new FormGroup({
    FullName : new FormControl('',[Validators.required,Validators.minLength(4),Validators.maxLength(15)]),
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
    this.service.registerUser(this.RegistrationForm.value).subscribe(  
      {next:(data)=>{
            console.log("login data"+data.message);
            this.dialog.open(SuccesspopupComponent,{
              width:'400px',
              disableClose: true,
                data: {
                  isSuccess:true,
                  title: 'Success',
                  message:data.message || 'Registered Successfully!'
                }
              });
            },
            error: (err: any) => {
            console.log("error message = "+err);
            this.dialog.open(SuccesspopupComponent,{
              width:'400px',
              disableClose: true,
                data: {
                 isSuccess:false,
                  title: 'Failed',
                  message:
                  err?.error?.message ||
                    'Something went wrong. Please try again.'
                }
              });
            }
    });
    this.RegistrationForm.reset();
  }
  login()
  {
    console.log("logged In button clicked")
    this.router.navigate(['/auth/login']);
  }
}
