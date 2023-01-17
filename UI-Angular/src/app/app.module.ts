import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { OrderListComponent } from './components/order-list/order-list.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { RouterModule } from '@angular/router';
import { GlobalErrorComponent } from './components/global-error/global-error.component';
import { VerificationDocumentsListComponent } from './components/verification-documents-list/verification-documents-list.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ManageWaterPointsComponent } from './components/manage-water-points/manage-water-points.component';
import { WaterPointItemComponent } from './components/water-point-item/water-point-item.component';
import { ReviewItemComponent } from './components/review-item/review-item.component';
import { ProductItemComponent } from './components/product-item/product-item.component';
import { MyOrdersComponent } from './components/my-orders/my-orders.component';
import { OrderConfirmingItemComponent } from './components/order-confirming-item/order-confirming-item.component';
import { MyOrdersItemComponent } from './components/my-orders-item/my-orders-item.component';
import { AuthGuard } from './guards/auth.guard';

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
    WaterPointListComponent,
    OrderListComponent,
    RegistrationComponent,
    GlobalErrorComponent,
    VerificationDocumentsListComponent,
    ProfileComponent,
    WaterPointItemComponent,
    ReviewItemComponent,
    ProductItemComponent,
    MyOrdersComponent,
    OrderConfirmingItemComponent,
    MyOrdersItemComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,FormsModule,ReactiveFormsModule,

    RouterModule.forRoot([
      {path: '', redirectTo: '/home', pathMatch: 'full'},
      {path: 'home', component: HomeComponent},
      {path: 'login', component: LoginComponent},
      {path: 'registration', component: RegistrationComponent},
      {path: 'order-confirming', component: OrderConfirmingComponent, canActivate: [AuthGuard]},
      {path: 'verification-documents', component: VerificationDocumentsListComponent, canActivate: [AuthGuard]},
      {path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},
      {path: 'manage-water-points', component:ManageWaterPointsComponent, canActivate: [AuthGuard]},
      {path: 'my-orders', component: MyOrdersComponent, canActivate: [AuthGuard]}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
