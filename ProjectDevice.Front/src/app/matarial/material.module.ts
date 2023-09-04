import { NgModule } from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import {MatSnackBarModule} from '@angular/material/snack-bar';

@NgModule({
  exports: [
    MatToolbarModule,
    MatCardModule,
    MatSnackBarModule
  ]
})
export class MaterialModule { }
