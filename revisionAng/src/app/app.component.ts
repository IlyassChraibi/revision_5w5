import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'revisionAng';

  /**
   *
   */
  constructor(public cookieService : CookieService) {
  }

  addCookie(){
    this.cookieService.set("MonCookie","une valeur");
  }

  removeCookie(){
    this.cookieService.delete("MonCookie");
  }

  hasCookie(){
    return this.cookieService.check("MonCookie");
  }
}
