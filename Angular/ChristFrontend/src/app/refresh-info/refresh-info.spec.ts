import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RefreshInfo } from './refresh-info';

describe('RefreshInfo', () => {
  let component: RefreshInfo;
  let fixture: ComponentFixture<RefreshInfo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RefreshInfo],
    }).compileComponents();

    fixture = TestBed.createComponent(RefreshInfo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
