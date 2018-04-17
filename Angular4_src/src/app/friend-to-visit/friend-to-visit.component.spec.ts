import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FriendToVisitComponent } from './friend-to-visit.component';

describe('FriendToVisitComponent', () => {
  let component: FriendToVisitComponent;
  let fixture: ComponentFixture<FriendToVisitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FriendToVisitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FriendToVisitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
