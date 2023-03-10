import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Order } from 'src/models/order';
import { OrderDetail } from 'src/models/order-detail';
import { ShoppingCart } from 'src/models/shoppingCart';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {


  shoppingCartURL: string = 'http://localhost:47392/api/shoppingCart';
  orderURL: string = 'http://localhost:47392/api/order';
  orderDetailURL: string = 'http://localhost:47392/api/orderDetail';

  constructor(private http: HttpClient, private errorService: ErrorService) {
    
  }

  GetTotalPrice():Observable<number>{
    return this.http.get<number>(`${this.shoppingCartURL}/getTotalPrice`);
  }

  ShoppingCartToOrderDetails(userId: number, orderId: number){
    return this.http.post(`${this.shoppingCartURL}/${userId}/submit-and-clear-cart/${orderId}`,{});
  }

  AddOrder(order: Order):Observable<number>{
    return this.http.post<number>(`${this.orderURL}`, order).pipe(
      catchError(this.errorHandler.bind(this))
    );
  }

  AddOrderDetail(orderDetail: OrderDetail):Observable<OrderDetail>{
    return this.http.post<OrderDetail>(`${this.orderDetailURL}`, orderDetail).pipe(
      catchError(this.errorHandler.bind(this))
    );
  }

  PutNewShoppingCart(shoppingCart: ShoppingCart):Observable<ShoppingCart>{
    return this.http.put<ShoppingCart>(`${this.shoppingCartURL}`, shoppingCart).pipe(
      catchError(this.errorHandler.bind(this))
    );
  }

  getAllShoppingCartsByUserId(userId: number): Observable<ShoppingCart[]>{
    return this.http.get<ShoppingCart[]>(`${this.shoppingCartURL}s/user/${userId}`).pipe(
      catchError(this.errorHandler.bind(this))
    )
   }

  getAllOrdersByUserId(userId: number): Observable<Order[]>{
  return this.http.get<Order[]>(`${this.orderURL}s/user/${userId}`).pipe(
    catchError(this.errorHandler.bind(this))
    )
  }

  deleteShoppingCart(id: number): Observable<Object>{
    return this.http.delete(`${this.shoppingCartURL}/${id}`);
  }

  private errorHandler(error: HttpErrorResponse){
    this.errorService.handle(error.message);
    return throwError(() => error.message)
  } 
}
