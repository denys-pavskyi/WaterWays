import { Component, OnInit } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { ModalsService } from 'src/app/services/modals.service';
import { WaterPointService } from 'src/app/services/water-point.service';
import { WaterPoint } from 'src/models/water-point';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loading = false;

  waterPoints$: Observable<WaterPoint[]> | undefined
  constructor(public waterPointService: WaterPointService, public modalService:ModalsService){

  }
  ngOnInit(): void {
    this.loading = true;
    this.waterPoints$ = this.waterPointService.getAll().pipe(
      tap(() => this.loading = false)
    );
  }

}
