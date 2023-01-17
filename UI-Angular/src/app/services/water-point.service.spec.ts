import { TestBed } from '@angular/core/testing';

import { WaterPointService } from './water-point.service';

describe('WaterPointService', () => {
  let service: WaterPointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WaterPointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
