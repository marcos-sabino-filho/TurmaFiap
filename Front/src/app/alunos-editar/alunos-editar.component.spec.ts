import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlunosEditarComponent } from './alunos-editar.component';

describe('AlunosEditarComponent', () => {
  let component: AlunosEditarComponent;
  let fixture: ComponentFixture<AlunosEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlunosEditarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlunosEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
