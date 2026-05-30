import { inject, Injectable, PLATFORM_ID } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import {
  isPlatformBrowser
} from '@angular/common';



@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private platformId =
    inject(PLATFORM_ID);
  constructor() { }
 private isBrowser(): boolean {
    return isPlatformBrowser(
      this.platformId
    );
  }
  saveLoginDetails(response:any):void {
    localStorage.setItem('token',
      response.userDetails.token
    );
    localStorage.setItem('user',JSON.stringify(response.userDetails));
  }

  getToken():string | null{
    return localStorage.getItem('token');
  }
  
  decodeToken():any{
    const token=this.getToken();
    if(!token)
      return null;
    return jwtDecode(token);
  }

  isTokenExpired():boolean{

    const decodedToken=this.decodeToken();
    if(!decodedToken?.exp)
    {
      return true;
    }
    const expTime=decodedToken.exp * 1000;
    return Date.now()>expTime;
  }
  getUser() :any{
    const user= localStorage.getItem('user');
    return user ? JSON.parse('user'):null;
  }

  isLoggedIn():boolean{
    const token=this.getToken();
    if(!token)return false;
    const payload = JSON.parse(atob(token.split('.')[1]));
    const expiry = payload.exp * 1000;

  return Date.now() < expiry;
  }

  logOut():void{
    localStorage.removeItem('token');
    localStorage.removeItem('user');
  }
}


