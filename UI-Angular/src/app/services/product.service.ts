import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Product } from 'src/models/product';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  productURL: string = 'http://localhost:47392/api/product';

  constructor(private http: HttpClient, private errorService: ErrorService) {
    
  }


  getById(productId: number): Observable<Product>{
    return this.http.get<Product>(`${this.productURL}/${productId}`).pipe(
      catchError(this.errorHandler.bind(this))
    )
   }

  getAllByWaterPointId(waterPointId: number): Observable<Product[]>{
    return this.http.get<Product[]>(`${this.productURL}s/waterPoint/${waterPointId}`).pipe(
      catchError(this.errorHandler.bind(this))
    )
   }

   private errorHandler(error: HttpErrorResponse){
    this.errorService.handle(error.message);
    return throwError(() => error.message)
  } 
}
