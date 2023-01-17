import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WaterPointItemComponent } from './water-point-item.component';

describe('WaterPointItemComponent', () => {
  let component: WaterPointItemComponent;
  let fixture: ComponentFixture<WaterPointItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WaterPointItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WaterPointItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
