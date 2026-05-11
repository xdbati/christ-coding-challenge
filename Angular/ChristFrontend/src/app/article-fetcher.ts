import { inject, Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ArticleFetcher {
  private http = inject(HttpClient);
  private apiUrl = environment.apiURL + '/api/articles';

  /**
   * Calls backend API in order to fetch the current sortiment of articles.
   * @returns 
   */
  public get(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
