import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Forecast } from '../interfaces/forecast.interface';


@Injectable({
  providedIn: 'root'
})
export class ForecastService {
  private apiURL = 'https://localhost:44336/v1/forecastgtfs/';

  constructor(private http: HttpClient) { }

  getLineasForecast(): Observable<Forecast[]>{
    return this.http.get<Forecast[]>(`${this.apiURL}forecast`);
  }


  
}