import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginHandlerComponent } from './login-handler.component';

describe('LoginHandlerComponent', () => {
  let component: LoginHandlerComponent;
  let fixture: ComponentFixture<LoginHandlerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginHandlerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LoginHandlerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
