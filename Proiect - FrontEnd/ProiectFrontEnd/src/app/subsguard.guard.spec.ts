import { TestBed } from '@angular/core/testing';

import { SubsguardGuard } from './subsguard.guard';

describe('SubsguardGuard', () => {
  let guard: SubsguardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(SubsguardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
