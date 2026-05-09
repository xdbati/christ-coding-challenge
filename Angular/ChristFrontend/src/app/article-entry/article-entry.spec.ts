import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleEntry } from './article-entry';

describe('ArticleEntry', () => {
  let component: ArticleEntry;
  let fixture: ComponentFixture<ArticleEntry>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArticleEntry],
    }).compileComponents();

    fixture = TestBed.createComponent(ArticleEntry);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
