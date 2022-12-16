import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurmaAlunosComponent } from './turma-alunos.component';

describe('TurmaAlunosComponent', () => {
  let component: TurmaAlunosComponent;
  let fixture: ComponentFixture<TurmaAlunosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TurmaAlunosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TurmaAlunosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
