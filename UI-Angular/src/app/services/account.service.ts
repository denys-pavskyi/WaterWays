import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, throwError } from 'rxjs';
import { LoginRequest } from 'src/models/loginRequest';
import { LoginResponse } from 'src/models/loginResponse';
import { RegisteredUser } from 'src/models/registered-user';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService implements OnInit {

  
  loginURL: string = 'http://localhost:47392/api/login';
  registrationURL: string ='http://localhost:47392/api/registeredUser';

  constructor(private http: HttpClient, 
    private errorService: ErrorService,
    private router: Router) {
    
   }
  ngOnInit(): void {
  }

  login(loginRequest: LoginRequest):Observable<LoginResponse>{
    return this.http.post<LoginResponse>(`${this.loginURL}`, loginRequest ).pipe(
      catchError(this.errorHandler.bind(this))
    );
  }

  register(user: RegisteredUser):Observable<Object>{
    return this.http.post<RegisteredUser>(`${this.registrationURL}`, user).pipe(
      catchError(this.errorHandler.bind(this))
    );
  }

  getById(userId: number): Observable<RegisteredUser>{
    return this.http.get<RegisteredUser>(`${this.registrationURL}/${userId}`).pipe(
      catchError(this.errorHandler.bind(this))
    )
   }

  
  get isLogged(): boolean{
    if(window.localStorage.getItem("Token")){
      return true;
    }else{
      return false;
    }
  }

  get isAdmin():boolean{
    let role = window.localStorage.getItem('Role');
    if(role){
      if(role=="Admin"){
        return true;
      }else{
        return false;
      }
    }else{
      return false;
    }
  }

  get isRepresentative():boolean{
    let role = window.localStorage.getItem('Role');
    if(role){
      if(role=="WaterPointRepresentative"){
        return true;
      }else{
        return false;
      }
    }else{
      return false;
    }
  }

  get userId(): number{
    if(window.localStorage.getItem('ID')){
      return Number(window.localStorage.getItem('ID'));
    }else{
      return -1;
    }
  }

  saveSession(loginResponse: LoginResponse) {
    window.localStorage.setItem('Username', loginResponse.username);
    window.localStorage.setItem('Role', loginResponse.role);
    window.localStorage.setItem('ID', loginResponse.id.toString());
    window.localStorage.setItem('Token', loginResponse.token);
  }

  

  logout() {
    window.localStorage.clear();
    this.router.navigate(['/login']);
  }

  private errorHandler(error: HttpErrorResponse){
    this.errorService.handle(error.message);
    return throwError(() => error.message)
  } 
}
