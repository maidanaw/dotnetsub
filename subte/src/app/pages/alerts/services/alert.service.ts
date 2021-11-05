import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Alert } from '../interfaces/alert.interface';


@Injectable({
  providedIn: 'root'
})
export class AlertService {

  private apiURL = 'https://localhost:44336/v1/alert/';



  constructor(private http: HttpClient) { }

  getActiveAlerts(): Observable<Alert[]>{
    const  headers = new HttpHeaders()
    .append('Content-Type', 'application/json')
    .append('Access-Control-Allow-Headers', 'Content-Type')
    .append('Access-Control-Allow-Methods', 'GET')  
    .append('Access-Control-Allow-Origin', '*');
    return this.http.get<Alert[]>(`${this.apiURL}status`, {headers});
  }

  getAllAlerts(): Observable<Alert[]>{
    return this.http.get<Alert[]>(`${this.apiURL}historic`);
  }
  
}
