import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderService } from 'src/app/services/order.service';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/models/product';
import { ShoppingCart } from 'src/models/shoppingCart';

@Component({
  selector: 'app-order-confirming-item',
  templateUrl: './order-confirming-item.component.html',
  styleUrls: ['./order-confirming-item.component.css']
})
export class OrderConfirmingItemComponent implements OnInit {

  @Input()item!: ShoppingCart;
  @Output() delete = new EventEmitter<any>();

  product$!: Observable<Product> ;

  constructor(public productService: ProductService, private orderService: OrderService){
    
   
  }

  ngOnInit(): void {
    this.product$ = this.productService.getById(this.item.productId);
  }

  deleteItem() {
    this.delete.emit(this.item.id);
  }


}
