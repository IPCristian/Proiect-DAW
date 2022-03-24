import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users/users.component';
import { MaterialModule } from '../material/material.module';
import { ChildComponent } from './child/child.component';


@NgModule({
  declarations: [
    UsersComponent,
    ChildComponent,
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    MaterialModule,
  ]
})
export class UsersModule { }
