import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { SongsService } from '../../services/songs.service';
import { SubsService } from '../../services/subs.service';

@Component({
  selector: 'app-subs',
  templateUrl: './subs.component.html',
  styleUrls: ['./subs.component.scss']
})
export class SubsComponent implements OnInit {

  public subs = [];
  public displayedColumns = ['id', 'userId'];

  constructor(
    private router: Router,
    private dataService: DataService,
    private songService: SubsService,
  ) { }

  ngOnInit(): void {
    this.songService.GetAllSubs().subscribe(
      (result) => {
        console.log(result);
        this.subs = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public goUsers(): void {
    this.router.navigate(['/users']);
  }

  public goSongs(): void {
    this.router.navigate(['/songs']);
  }

}
