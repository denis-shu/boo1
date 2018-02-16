import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Router, RouterStateSnapshot } from '@angular/router';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(private auth: AuthService, private router: Router) { }

  canActivate(route, state: RouterStateSnapshot) {
  return  this.auth.user$.map(user => {
      // tslint:disable-next-line:curly
      if (user)
        return true;
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }} );
      return false;
    });
  }
}
