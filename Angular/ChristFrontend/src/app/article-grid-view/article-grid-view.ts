import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { AllCommunityModule, ColDef, GridApi, GridReadyEvent, ModuleRegistry } from 'ag-grid-community';

ModuleRegistry.registerModules([AllCommunityModule]);

@Component({
  selector: 'app-article-grid-view',
  imports: [AgGridAngular],
  templateUrl: './article-grid-view.html',
  styleUrl: './article-grid-view.scss',
})
export class ArticleGridView implements OnChanges {
  @Input() articles : any[] = [];
  @Input() currentLang = 'de';

  noRowsTemplate = '<span class="no-rows">Keine Artikel gefunden.</span>';
  private gridApi!: GridApi;

  getField(field: Record<string, string> | null, fallback = '-'): string {
    if (!field) return fallback;

    return field[this.currentLang] ?? field['de'] ?? fallback;
  }

  rowData : any[] = [];

  ngOnChanges(changes: SimpleChanges) : void {
    if (changes['articles'] || changes['currentLang']) {
      this.rowData = this.mapToRows();
    }
  }

  onGridReady(event: GridReadyEvent) : void {
    this.gridApi = event.api;
    // this.gridApi.sizeColumnsToFit();
  }

  onFirstDataRendered(): void {
    this.gridApi.autoSizeAllColumns(false);
  }

  private mapToRows(): any[] {
    return this.articles.map(article => ({
      articleId: article.articleId,
      MRK:       article.MRK  ?? '-',
      MAT:       this.getField(article.MAT),
      MAT2:      this.getField(article.MAT2),
      MAT3:      this.getField(article.MAT3),
      LEG:       this.getField(article.LEG),
      LEG2:      this.getField(article.LEG2),
      LEG3:      this.getField(article.LEG3),
      KOLL:      article.KOLL  ?? '-',
      WRG_2:     article.WRG_2  ?? '-',
      WHG_2:     article.WHG_2  ?? '-',
      ZIEL:      this.getField(article.ZIEL),
    }));
  }

  colDefs : ColDef[] = [
      { field: 'articleId', headerName: 'ID', pinned: 'left' },
      { field: 'MRK', headerName: 'Marke' },
      { field: 'MAT', headerName: 'Material 1' },
      { field: 'MAT2', headerName: 'Material 2' },
      { field: 'MAT3', headerName: 'Material 3' },
      { field: 'LEG', headerName: 'Legierung 1' },
      { field: 'LEG2', headerName: 'Legierung 2' },
      { field: 'LEG3', headerName: 'Legierung 3' },
      { field: 'KOLL', headerName: 'Kollektion' },
      { field: 'WRG_2', headerName: 'Warengruppe' },
      { field: 'WHG_2', headerName: 'Warenhauptgruppe' },
      { field: 'ZIEL', headerName: 'Geschlecht' }
    ];
}
