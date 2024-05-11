import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetClassSummaryComponent } from './asset-class-summary.component';

describe('AssetClassSummaryComponent', () => {
  let component: AssetClassSummaryComponent;
  let fixture: ComponentFixture<AssetClassSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssetClassSummaryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AssetClassSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
