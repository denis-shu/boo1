import { AppUser } from './../models/app-user';
import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'bs-navbar',
  templateUrl: './bs-navbar.component.html',
  styleUrls: ['./bs-navbar.component.css']
})
export class BsNavbarComponent {
  appUser: AppUser;

  constructor(private afAuth: AuthService) {
    this.afAuth.appUser$.subscribe(appUser => {
    this.appUser = appUser;
    
    });

  }

  logout() {
    this.afAuth.logout();
  }
}
