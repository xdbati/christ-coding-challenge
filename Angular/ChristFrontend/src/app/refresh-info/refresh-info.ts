import { Component, Input, OnInit, OnDestroy, NgZone, signal, computed } from '@angular/core';

@Component({
  selector: 'app-refresh-info',
  imports: [],
  templateUrl: './refresh-info.html',
  styleUrl: './refresh-info.scss',
})
export class RefreshInfo implements OnInit, OnDestroy {
  @Input() lastRefreshed: Date | null = null;

  private intervalId: any;
  elapsedSeconds = signal(0);
  isStale = computed(() => this.elapsedSeconds() >= 300);

  constructor(private ngZone: NgZone) {}

  ngOnInit(): void {
    // Run timer outside Angular to avoid unnecessary change detection cycles
    this.ngZone.runOutsideAngular(() => {
      this.intervalId = setInterval(() => {
        if (!this.lastRefreshed) return;
        const diff = Math.floor((Date.now() - this.lastRefreshed.getTime()) / 1000);

        // Bring the signal update back inside Angular so it triggers re-render
        this.ngZone.run(() => {
          this.elapsedSeconds.set(diff);
        });
      }, 1000);
    });
  }

  ngOnDestroy(): void {
    clearInterval(this.intervalId);
  }

  getFormattedElapsed(): string {
    const s = this.elapsedSeconds();
    const minutes = Math.floor(s / 60);
    const hours = Math.floor(minutes / 60);

    if (s < 60) return `${s} Sekunden`;
    if (minutes < 60) return `${minutes} Minuten`;
    return `${hours} Stunden`;
  }
}