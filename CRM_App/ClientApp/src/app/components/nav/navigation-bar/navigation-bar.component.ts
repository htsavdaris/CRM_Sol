import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  @Output() toggleSidenav = new EventEmitter<void>();
  private returnUrl = '/';

  constructor() { }

  ngOnInit() {
  }

}
