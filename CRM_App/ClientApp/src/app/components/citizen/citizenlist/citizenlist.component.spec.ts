import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CitizenlistComponent } from './citizenlist.component';

describe('CitizenlistComponent', () => {
  let component: CitizenlistComponent;
  let fixture: ComponentFixture<CitizenlistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CitizenlistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CitizenlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
