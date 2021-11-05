import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AlertsRoutingModule } from './alerts-routing.module';
import { AlertsComponent } from './alerts.component';
import { MaterialModule } from 'src/app/material.module';


@NgModule({
  declarations: [
    AlertsComponent
  ],
  imports: [
    CommonModule,
    AlertsRoutingModule,
    MaterialModule
  ]
})
export class AlertsModule { }
