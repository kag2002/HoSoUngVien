import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HosoungvienComponent } from './hosoungvien.component';

describe('HosoungvienComponent', () => {
  let component: HosoungvienComponent;
  let fixture: ComponentFixture<HosoungvienComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HosoungvienComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HosoungvienComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
