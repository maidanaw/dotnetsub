import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoricRoutingModule } from './historic-routing.module';
import { HistoricComponent } from './historic.component';
import { MaterialModule } from 'src/app/material.module';

@NgModule({
  declarations: [
    HistoricComponent
  ],
  imports: [
    CommonModule,
    HistoricRoutingModule,
    MaterialModule
  ]
})
export class HistoricModule { }
