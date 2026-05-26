import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../Environments/environment';

@Injectable({
  providedIn: 'root'
})
export class APIServiceService {

  constructor(private http:HttpClient) { }

// private http = Inject(HttpClient);
 private apiUrl= environment.apiUrl;

 registerUser(data:any)
{
  console.log("api reached at registerUser - start");
  return this.http.post<any>(`${this.apiUrl}/Auth/registerUser`,data);
}

login(data:any)
{
    console.log("api reached at login - start");
return this.http.post<any>(`${this.apiUrl}/Auth/login`,data);
}
}
