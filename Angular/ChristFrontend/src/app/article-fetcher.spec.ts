import { TestBed } from '@angular/core/testing';

import { ArticleFetcher } from './article-fetcher';

describe('ArticleFetcher', () => {
  let service: ArticleFetcher;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ArticleFetcher);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
