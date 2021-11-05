import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/index', pathMatch: 'full' },
  { path: 'index', loadChildren: () => import('./pages/index/index.module').then(m => m.IndexModule) },
  { path: 'alerts', loadChildren: () => import('./pages/alerts/alerts.module').then(m => m.AlertsModule) },
  { path: 'forecast', loadChildren: () => import('./pages/forecast/forecast.module').then(m => m.ForecastModule) },
  { path: 'historic', loadChildren: () => import('./pages/historic/historic.module').then(m => m.HistoricModule) },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }