import { Component, Input, OnInit } from '@angular/core';
import { ModalsService } from 'src/app/services/modals.service';
import { WaterPoint, WaterPointType } from 'src/models/water-point';

@Component({
  selector: 'app-water-point-item',
  templateUrl: './water-point-item.component.html',
  styleUrls: ['./water-point-item.component.css']
})
export class WaterPointItemComponent implements OnInit {
  @Input()waterPoint!: WaterPoint;

  constructor(public modalService: ModalsService){

  }
  ngOnInit(): void {
    
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
