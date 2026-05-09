import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ArticleFetcher } from './article-fetcher';
import { LanguagePicker } from "./language-picker/language-picker";
import { ArticleGridView } from "./article-grid-view/article-grid-view";
import { RefreshInfo } from "./refresh-info/refresh-info";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LanguagePicker, ArticleGridView, RefreshInfo],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = 'ChristFrontend';
  lastRefreshed = signal<Date | null>(null);

  // Language
  currentLang = signal('de');                               // Current language, default to German
  readonly languages = ['de', 'nl', 'fr', 'sv', 'da', 'it', 'pl'];   // Available languages
  
  onLanguageChanged(lang: string) : void {
    this.currentLang.set(lang);
  }

  // Articles
  articles = signal<any[]>([]);                             // Fetched articles
  articleFetcher = inject(ArticleFetcher);        

  constructor() {
    this.articleFetcher.get().subscribe(articles => {
      this.articles.set(articles);
      this.lastRefreshed.set(new Date());
    });
  }
}
