import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderConfirmingItemComponent } from './order-confirming-item.component';

describe('OrderConfirmingItemComponent', () => {
  let component: OrderConfirmingItemComponent;
  let fixture: ComponentFixture<OrderConfirmingItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderConfirmingItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderConfirmingItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
