import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MUsersService {

  public url = 'https://localhost:44338/api/User';

  constructor(
    public http: HttpClient,
  ) { }


  public GetAllUsers(): Observable<any> {
    return this.http.get(`${this.url}`);
  }

}
