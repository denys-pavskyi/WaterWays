import { Component, Input, OnInit } from '@angular/core';
import { Order, OrderStatus } from 'src/models/order';

@Component({
  selector: 'app-my-orders-item',
  templateUrl: './my-orders-item.component.html',
  styleUrls: ['./my-orders-item.component.css']
})
export class MyOrdersItemComponent implements OnInit {

  @Input()order!: Order;


  constructor(){

  }
  ngOnInit(): void {
    
  }

  enumToString(enumValue: any): string {
    return OrderStatus[enumValue];
  }
}
