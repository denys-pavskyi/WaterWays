import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { OrderService } from 'src/app/services/order.service';
import { Order, OrderStatus } from 'src/models/order';
import { ShoppingCart } from 'src/models/shoppingCart';

@Component({
  selector: 'app-order-confirming',
  templateUrl: './order-confirming.component.html',
  styleUrls: ['./order-confirming.component.css']
})
export class OrderConfirmingComponent implements OnInit {
  
  items$!: Observable<ShoppingCart[]>;
  loading = false;
  form: FormGroup;
  totalPrice = 0;
  orderId!: number;

  constructor(public orderService: OrderService, private router: Router){
    this.form = new FormGroup({
      'address': new FormControl('', [Validators.required]),
      'date': new FormControl(null, [Validators.required]),
      'orderText': new FormControl('', [Validators.required]),
      'phone': new FormControl('', [Validators.required])
    });
  }

  OnSubmit(){
    const orderText = this.form.get('orderText')?.value;
    const userid = Number(window.localStorage.getItem('ID'));
    const orderDate = this.form.get('date')?.value;
    const phone = this.form.get('phone')?.value;
    const address = this.form.get('address')?.value;

    let order = new Order(orderText, userid, orderDate, phone, address, this.totalPrice, true, OrderStatus.InProgress);

    this.orderService.AddOrder(order).subscribe(
      order => this.orderId = order.id
    )

    this.orderService.ShoppingCartToOrderDetails(Number(window.localStorage.getItem('ID')), this.orderId).subscribe({
      next: (data => {
        console.log(data);
        this.router.navigate(['/home'])
      })
    });
  }


  ngOnInit(): void {
    this.orderService.GetTotalPrice().subscribe(
      data => this.totalPrice = data
    );

    this.loading = true;
    this.items$ = this.orderService.getAllShoppingCartsByUserId(Number(window.localStorage.getItem('ID'))).pipe(
      tap(() => this.loading = false)
    );
    
  }

  deleteItem(id: number){
    this.orderService.deleteShoppingCart(id).subscribe();
  }
}
