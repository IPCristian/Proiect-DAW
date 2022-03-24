import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../../../services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private router: Router,
    private dataService: DataService,
  ) { }

  get email(): AbstractControl {
    return this.loginForm.get('email') as AbstractControl;
  }
  get password(): AbstractControl {
    return this.loginForm.get('password') as AbstractControl;
  }

  ngOnInit(): void {
  }

  public login(): void {
    this.dataService.changeUserData(this.loginForm.value);
    localStorage.setItem('Role', 'Admin');
    this.router.navigate(['/users']);
  }

}
