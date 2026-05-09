import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-article-entry',
  imports: [],
  templateUrl: './article-entry.html',
  styleUrl: './article-entry.scss',
})
export class ArticleEntry {
  @Input() articleId = '';
  @Input() MRK = '';
  @Input() MAT = '';
  @Input() MAT2 = '';
  @Input() MAT3 = '';
  @Input() LEG = '';
  @Input() LEG2 = '';
  @Input() LEG3 = '';
  @Input() KOLL = '';
  @Input() WRG_2 = '';
  @Input() WHG_2 = '';
  @Input() ZIEL = '';
}
