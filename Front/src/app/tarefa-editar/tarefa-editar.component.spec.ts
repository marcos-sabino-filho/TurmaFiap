import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TarefaEditarComponent } from './tarefa-editar.component';

describe('TarefaEditarComponent', () => {
  let component: TarefaEditarComponent;
  let fixture: ComponentFixture<TarefaEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TarefaEditarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TarefaEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
