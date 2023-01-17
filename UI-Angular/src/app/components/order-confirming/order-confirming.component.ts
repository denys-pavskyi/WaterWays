import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderService } from 'src/app/services/order.service';
import { ShoppingCart } from 'src/models/shoppingCart';

@Component({
  selector: 'app-order-confirming',
  templateUrl: './order-confirming.component.html',
  styleUrls: ['./order-confirming.component.css']
})
export class OrderConfirmingComponent implements OnInit {
  
  items$!: Observable<ShoppingCart[]>;

  constructor(public orderService: OrderService){

  }

  ngOnInit(): void {
    this.items$ = this.orderService.getAllShoppingCartsByUserId(Number(window.localStorage.getItem('ID')));
  
  }
}
