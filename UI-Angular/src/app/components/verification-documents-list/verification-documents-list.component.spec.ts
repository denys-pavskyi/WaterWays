import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerificationDocumentsListComponent } from './verification-documents-list.component';

describe('VerificationDocumentsListComponent', () => {
  let component: VerificationDocumentsListComponent;
  let fixture: ComponentFixture<VerificationDocumentsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerificationDocumentsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VerificationDocumentsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
