import { Component, Input, OnInit } from '@angular/core';
import { ShoppingCart } from 'src/models/shoppingCart';

@Component({
  selector: 'app-order-confirming-item',
  templateUrl: './order-confirming-item.component.html',
  styleUrls: ['./order-confirming-item.component.css']
})
export class OrderConfirmingItemComponent implements OnInit {

  @Input()item!: ShoppingCart;


  constructor(){

  }
  ngOnInit(): void {
    
  }



}
