import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SongComponent } from './song/song.component';
import { SongsComponent } from './songs.component';

const routes: Routes = [
  {
    path: '',
    component: SongsComponent,
  },
  {
    path: ':id',
    component: SongComponent, 
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SongsRoutingModule { }
