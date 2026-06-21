import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DueComponent } from './due.component';

describe('DueComponent', () => {
  let component: DueComponent;
  let fixture: ComponentFixture<DueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DueComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
