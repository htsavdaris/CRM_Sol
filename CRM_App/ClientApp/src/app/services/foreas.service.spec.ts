import { TestBed } from '@angular/core/testing';

import { ForeasService } from './foreas.service';

describe('ForeasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ForeasService = TestBed.get(ForeasService);
    expect(service).toBeTruthy();
  });
});
