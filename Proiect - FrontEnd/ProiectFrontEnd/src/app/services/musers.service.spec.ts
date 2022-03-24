import { TestBed } from '@angular/core/testing';

import { MUsersService } from './musers.service';

describe('MUsersService', () => {
  let service: MUsersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MUsersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
