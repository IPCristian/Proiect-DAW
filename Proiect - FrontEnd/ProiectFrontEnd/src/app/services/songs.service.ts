import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SongsService {

  public url = 'https://localhost:44338/api/Song';

  constructor(
    public http: HttpClient,
  ) { }

  public GetAllSongs(): Observable<any> {
    return this.http.get(`${this.url}`);
  }

  public getSongById(id): Observable<any> {
    return this.http.get(`${this.url}/${id}`);
  }
}
