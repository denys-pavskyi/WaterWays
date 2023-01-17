import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Review } from 'src/models/review';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  reviewURL: string = 'http://localhost:47392/api/review';

  constructor(private http: HttpClient, private errorService: ErrorService) {
    
  }

  getAllByWaterPointId(waterPointId: number): Observable<Review[]>{
    return this.http.get<Review[]>(`${this.reviewURL}s/waterPoint/${waterPointId}`).pipe(
      catchError(this.errorHandler.bind(this))
    )
   }

   private errorHandler(error: HttpErrorResponse){
    this.errorService.handle(error.message);
    return throwError(() => error.message)
  } 
}
