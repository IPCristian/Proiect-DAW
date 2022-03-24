import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SubsRoutingModule } from './subs-routing.module';
import { SubsComponent } from './subs.component';
import { MaterialModule } from '../material/material.module';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    SubsComponent
  ],
  imports: [
    CommonModule,
    SubsRoutingModule,
    MaterialModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatIconModule,
  ],
  exports: [
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
  ]
})
export class SubsModule { }
