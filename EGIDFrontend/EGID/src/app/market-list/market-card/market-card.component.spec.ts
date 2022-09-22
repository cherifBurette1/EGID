import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketCardComponent } from './market-card.component';

describe('MarketCardComponent', () => {
  let component: MarketCardComponent;
  let fixture: ComponentFixture<MarketCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MarketCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
