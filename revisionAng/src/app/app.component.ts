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

  registerUser() {
    // Appelez votre service d'enregistrement utilisateur
    //this.authService.registerUserHardCoded();
  }

  
loginUser() {
  // Appelez votre service de connexion utilisateur
  //this.authService.loginUserHardCoded();
}

// Dans votre composant
getRequestWithCookie() {
  // Appelez votre service pour effectuer une requête GET avec le cookie
  //this.apiService.getDataWithCookie().subscribe(response => {
    // Traitez la réponse ici
 // });
}

// Dans votre composant
logoutUser() {
  // Appelez votre service de déconnexion utilisateur
  //this.authService.logoutUser();
}

}
