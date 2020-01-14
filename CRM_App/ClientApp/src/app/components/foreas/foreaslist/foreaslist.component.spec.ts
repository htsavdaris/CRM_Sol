import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ForeaslistComponent } from './foreaslist.component';

describe('ForeaslistComponent', () => {
  let component: ForeaslistComponent;
  let fixture: ComponentFixture<ForeaslistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ForeaslistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ForeaslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
