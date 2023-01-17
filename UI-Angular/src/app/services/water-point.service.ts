import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { WaterPoint } from 'src/models/water-point';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class WaterPointService {

  waterPointURL: string = 'http://localhost:47392/api/waterPoint';

  constructor(private http: HttpClient, private errorService: ErrorService) {
    
  }


  waterPoints: WaterPoint[] = []

  getAll(): Observable<WaterPoint[]>{
    return this.http.get<WaterPoint[]>(`${this.waterPointURL}s/`).pipe(
      tap(waterPoints => this.waterPoints = waterPoints),
      catchError(this.errorHandler.bind(this))
    )
   }

   getById(waterPointId: number): Observable<WaterPoint[]>{
    return this.http.get<WaterPoint[]>(`${this.waterPointURL}/${waterPointId}`).pipe(
      catchError(this.errorHandler.bind(this))
    )
   }



   private errorHandler(error: HttpErrorResponse){
    this.errorService.handle(error.message);
    return throwError(() => error.message)
  } 

}
