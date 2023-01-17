import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderConfirmingComponent } from './order-confirming.component';

describe('OrderConfirmingComponent', () => {
  let component: OrderConfirmingComponent;
  let fixture: ComponentFixture<OrderConfirmingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderConfirmingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderConfirmingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
