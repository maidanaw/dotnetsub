import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Forecast } from './interfaces/forecast.interface';
import { ForecastService } from './services/forecast.service';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.scss']
})
export class ForecastComponent implements OnInit {

  forecastgtfs! : Forecast[];
  constructor(private forecastService: ForecastService) { }

  ngOnInit(): void {
    this.forecastService.getLineasForecast()
    .pipe(tap((forecastgtfs: Forecast[]) => this.forecastgtfs = forecastgtfs))
    .subscribe();
  }

}
