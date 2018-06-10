
import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
   public teams: Array<string>;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/TeamDetails').subscribe(result => {
            this.teams = result.json() as Array<string>;
        }, error => console.error(error));
    }
}
