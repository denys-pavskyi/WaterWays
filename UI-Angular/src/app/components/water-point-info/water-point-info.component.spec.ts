import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WaterPointInfoComponent } from './water-point-info.component';

describe('WaterPointInfoComponent', () => {
  let component: WaterPointInfoComponent;
  let fixture: ComponentFixture<WaterPointInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WaterPointInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WaterPointInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
