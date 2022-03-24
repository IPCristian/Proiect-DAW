import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { SongsService } from '../../services/songs.service';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.scss']
})
export class SongsComponent implements OnInit {

  public songs = [];
  public displayedColumns = ['id', 'name', 'artist', 'genre', 'profile'];

  constructor(
    private router: Router,
    private dataService: DataService,
    private songService: SongsService,
  ) { }

  ngOnInit(): void {
    this.songService.GetAllSongs().subscribe(
      (result) => {
        console.log(result);
        this.songs = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }


  public goUsers(): void {
    this.router.navigate(['/users']);
  }

  public goSubs(): void {
    this.router.navigate(['/subs']);
  }

  public goToSong(id): void {
    this.router.navigate(['/songs', id]);
  }
}
