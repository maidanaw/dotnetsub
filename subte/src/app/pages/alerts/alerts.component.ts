import { Component, OnInit } from '@angular/core';
import { Alert } from './interfaces/alert.interface';
import { AlertService } from './services/alert.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-alerts',
  templateUrl: './alerts.component.html',
  styleUrls: ['./alerts.component.scss']
})
export class AlertsComponent implements OnInit {
  alerts! : Alert[];
  constructor(private alertService: AlertService) { }

  ngOnInit(): void {
    this.alertService.getActiveAlerts()
    .pipe(tap((alerts: Alert[]) => this.alerts = alerts))
    .subscribe();
  }

}
