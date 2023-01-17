import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { ModalComponent } from './components/modal/modal.component';
import { WaterPointInfoComponent } from './components/water-point-info/water-point-info.component';
import { ShoppingCartModalComponent } from './components/shopping-cart-modal/shopping-cart-modal.component';
import { ShoppingCartInfoComponent } from './components/shopping-cart-info/shopping-cart-info.component';
import { OrderConfirmingComponent } from './components/order-confirming/order-confirming.component';
import { WaterPointListComponent } from './components/water-point-list/water-point-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    NavMenuComponent,
    ModalComponent,
    WaterPointInfoComponent,
    ShoppingCartModalComponent,
    ShoppingCartInfoComponent,
    OrderConfirmingComponent,
    WaterPointListComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
