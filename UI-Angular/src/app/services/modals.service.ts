import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { WaterPoint } from 'src/models/water-point';

@Injectable({
  providedIn: 'root'
})
export class ModalsService {

  constructor() { }

  isShowingWaterPointDetails$ = new BehaviorSubject<boolean>(false)
  currentWaterPoint!: WaterPoint;

  openWaterPoint(waterPoint: WaterPoint){
    this.currentWaterPoint = waterPoint;
    this.isShowingWaterPointDetails$.next(true);
  }


  close(){
    this.isShowingWaterPointDetails$.next(false);
  }
}
