import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleGridView } from './article-grid-view';

describe('ArticleGridView', () => {
  let component: ArticleGridView;
  let fixture: ComponentFixture<ArticleGridView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArticleGridView],
    }).compileComponents();

    fixture = TestBed.createComponent(ArticleGridView);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
