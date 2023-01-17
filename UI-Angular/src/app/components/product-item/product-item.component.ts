import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/services/account.service';
import { Product, ProductType } from 'src/models/product';
import { RegisteredUser } from 'src/models/registered-user';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  @Input()product! : Product;

  isAdded:boolean = false;
  quantity:number = 0;

  constructor(){

  }

  ngOnInit(): void {
  }

  enumToString(enumValue: any): string {
    return ProductType[enumValue];
  }

  addToCart(): void{

  }

  deleteFromCart(): void{

  }
}
