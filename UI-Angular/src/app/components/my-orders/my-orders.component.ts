import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderService } from 'src/app/services/order.service';
import { Order } from 'src/models/order';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.css']
})
export class MyOrdersComponent implements OnInit {
  
  orders$!: Observable<Order[]>


  constructor(public orderService: OrderService){

  }

  ngOnInit(): void {
    this.orders$ = this.orderService.getAllOrdersByUserId(Number(window.localStorage.getItem('ID')));
  }
}
