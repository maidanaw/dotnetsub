import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ForecastRoutingModule } from './forecast-routing.module';
import { ForecastComponent } from './forecast.component';
import { MaterialModule } from 'src/app/material.module';

@NgModule({
  declarations: [
    ForecastComponent
  ],
  imports: [
    CommonModule,
    ForecastRoutingModule,
    MaterialModule
  ]
})
export class ForecastModule { }
