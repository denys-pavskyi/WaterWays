import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WaterPointListComponent } from './water-point-list.component';

describe('WaterPointListComponent', () => {
  let component: WaterPointListComponent;
  let fixture: ComponentFixture<WaterPointListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WaterPointListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WaterPointListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
