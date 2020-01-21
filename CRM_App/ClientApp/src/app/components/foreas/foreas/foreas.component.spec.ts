import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ForeasComponent } from './foreas.component';

describe('ForeasComponent', () => {
  let component: ForeasComponent;
  let fixture: ComponentFixture<ForeasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ForeasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ForeasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
