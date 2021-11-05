import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Alert } from '../alerts/interfaces/alert.interface';
import { AlertService } from '../alerts/services/alert.service';

@Component({
  selector: 'app-historic',
  templateUrl: './historic.component.html',
  styleUrls: ['./historic.component.scss']
})
export class HistoricComponent implements OnInit {

  hAlerts! : Alert[];
  displayedColumns: string[] = ['alertCode', 'title', 'activeStart', 'activeEnd', 'cause', 'effect'];

  constructor(private alertService: AlertService) { }

  ngOnInit(): void {
    this.alertService.getAllAlerts()
    .pipe(tap((alerts: Alert[]) => this.hAlerts = alerts))
    .subscribe();
  }

}
