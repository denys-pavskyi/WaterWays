import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageWaterPointsComponent } from './manage-water-points.component';

describe('ManageWaterPointsComponent', () => {
  let component: ManageWaterPointsComponent;
  let fixture: ComponentFixture<ManageWaterPointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageWaterPointsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageWaterPointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
