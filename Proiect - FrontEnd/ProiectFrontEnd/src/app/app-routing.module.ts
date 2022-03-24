import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { SubsguardGuard } from './subsguard.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],          
    children: [
      {
        path: '',
        loadChildren: () => import('src/app/modules/users/users.module').then(m => m.UsersModule),
      },
    ]
  },
  
  {
    path: 'login',
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule),
  },
  {
    path: 'subs',
    canActivate: [SubsguardGuard],
    loadChildren: () => import('src/app/modules/subs/subs.module').then(m => m.SubsModule),
  },
  {
    path: 'songs',
    canActivate: [SubsguardGuard],
    loadChildren: () => import('src/app/modules/songs/songs.module').then(m => m.SongsModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
