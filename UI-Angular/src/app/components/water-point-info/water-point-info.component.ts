import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ModalsService } from 'src/app/services/modals.service';
import { ProductService } from 'src/app/services/product.service';
import { ReviewService } from 'src/app/services/review.service';
import { Product } from 'src/models/product';
import { Review } from 'src/models/review';
import { WaterPoint, WaterPointType } from 'src/models/water-point';

@Component({
  selector: 'app-water-point-info',
  templateUrl: './water-point-info.component.html',
  styleUrls: ['./water-point-info.component.css']
})
export class WaterPointInfoComponent implements OnInit {

  waterPoint!: WaterPoint;
  products$: Observable<Product[]> | undefined
  reviews$: Observable<Review[]> | undefined

  constructor(public modalService: ModalsService, 
    public productService: ProductService, public reviewService: ReviewService){
    this.waterPoint = modalService.currentWaterPoint;
  }

  ngOnInit(): void {
    this.products$ = this.productService.getAllByWaterPointId(this.waterPoint.id);
    this.reviews$ = this.reviewService.getAllByWaterPointId(this.waterPoint.id);

  }


  enumToString(enumValue: any): string {
    return WaterPointType[enumValue];
  }

  getPhotoUrl(){
    if(this.waterPoint.photoUrl!= null && this.waterPoint.photoUrl!=""){
      return this.waterPoint.photoUrl;
    }else{
      return "no_photo.PNG";
    }
  }
}
