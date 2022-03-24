import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DataService } from '../../../services/data.service';
import { MUsersService } from '../../../services/musers.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit, OnDestroy {

  public subscription: Subscription;
  public loggedUser;
  public parentMessage = 'Message from the parent component';
  public users = [];

  constructor(
    private router: Router,
    private dataService: DataService,
    private userService: MUsersService,
  ) { }

  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe(user => this.loggedUser = user);
    this.userService.GetAllUsers().subscribe(
      (result) => {
        console.log(result);
        this.users = result;  
      },
      (error) => {
        console.error(error);
      }
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public logout(): void {
    localStorage.setItem('Role', 'Anonymous');
    this.router.navigate(['/login']);
  }

  public goSongs(): void {
    this.router.navigate(['/songs']);
  }

  public goSubs(): void {
    this.router.navigate(['/subs']);
  }

  public receiveMessage(event): void {
    console.log(event);
  }

}
