import { NgModule } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { CommonModule } from '@angular/common';
@NgModule({
  exports: [
    CommonModule,
    MatTableModule
  ]
})
export class AdminMaterialModule { }

