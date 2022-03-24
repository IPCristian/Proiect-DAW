import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { SongsService } from '../../../services/songs.service';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.scss']
})
export class SongComponent implements OnInit {

  public subscription: Subscription;
  public id;

  constructor(
    private route: ActivatedRoute,
    private songsService: SongsService,
  ) { }

  ngOnInit() {
    this.subscription = this.route.params.subscribe(params => {
      this.id = +params['id'];
      if (this.id) {
        this.getSong();
      }
    });
  }

  public getSong(): void {
    console.log(this.id);
    this.songsService.getSongById(this.id).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

}
