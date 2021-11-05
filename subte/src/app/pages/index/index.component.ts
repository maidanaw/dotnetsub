import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent {

  constructor(private router: Router) {}

  goTo(route: string): void {

    if (route == 'alerts') {
      this.router.navigate(['/alerts']);
    } else if (route == 'arrival') {
      this.router.navigate(['/forecast']);
    } else {
      this.router.navigate(['/historic']);
    }

  }

}
