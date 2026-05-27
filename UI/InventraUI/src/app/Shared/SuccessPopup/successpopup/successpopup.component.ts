import { Component, inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef,MatDialogClose } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import {Router} from '@angular/router'

@Component({
  selector: 'app-successpopup',
  standalone: true,
  imports: [MatButtonModule,MatDialogModule,MatDialogClose],
  templateUrl: './successpopup.component.html',
  styleUrl: './successpopup.component.css'
})
export class SuccesspopupComponent {

 
  constructor(private router: Router) {}

   readonly dialogRef = inject(MatDialogRef);
   readonly data = inject(MAT_DIALOG_DATA);

  goToHome(): void {
    this.dialogRef.close();
    this.router.navigate(['/home']); // your homepage route
  }
}
