import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubsService {

  public url = 'https://localhost:44338/api/Subscription';

  constructor(
    public http: HttpClient,
  ) { }

  public GetAllSubs(): Observable<any> {
    return this.http.get(`${this.url}`);
  }
}
