import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/services/account.service';
import { OrderService } from 'src/app/services/order.service';
import { Product, ProductType } from 'src/models/product';
import { RegisteredUser } from 'src/models/registered-user';
import { ShoppingCart } from 'src/models/shoppingCart';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  @Input()product! : Product;

  form: FormGroup;
  isAdded:boolean = false;

  constructor(public orderService: OrderService, private errorService: OrderService){
    this.form = new FormGroup({
      'quantity': new FormControl('', [Validators.required])
    })
  }

  ngOnInit(): void {
  }

  enumToString(enumValue: any): string {
    return ProductType[enumValue];
  }

  addToCart(): void{
    const productId = this.product.id;
    const userId = Number(window.localStorage.getItem('ID'));
    const quantity = this.form.get('quantity')?.value;
    const unitPrice = this.product.price;
    const totalPrice = quantity * unitPrice;

    if(quantity!="" && quantity!=0){
      let shoppingCart = new ShoppingCart(productId, quantity, unitPrice, totalPrice, userId);
      this.orderService.PutNewShoppingCart(shoppingCart).subscribe();
    }
    
  }

  getPhotoUrl(){
    if(this.product.photoUrl!= null && this.product.photoUrl!=""){
      return this.product.photoUrl;
    }else{
      return "no_photo.PNG";
    }
  }
  
}
