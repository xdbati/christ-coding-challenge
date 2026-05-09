import { Component, Input, output } from '@angular/core';

@Component({
  selector: 'app-language-picker',
  imports: [],
  templateUrl: './language-picker.html',
  styleUrl: './language-picker.scss',
})
export class LanguagePicker {
  @Input() currentLang = 'de';
  @Input() languages: string[] = [];

  languageChanged = output<string>();

  changeLanguage(lang: string) : void {
    if (!this.languages.includes(lang)) return;
    this.languageChanged.emit(lang);
  }
}
