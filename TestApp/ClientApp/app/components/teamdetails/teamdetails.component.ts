import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';


@Component({
  selector: 'teamdetails',
  templateUrl: './teamdetails.component.html'
})
export class TeamDetailsComponent {
  public team: Team;
  public members: Array<Person>;
  constructor(public http: Http,private route: ActivatedRoute,
    private router: Router, @Inject('BASE_URL') public baseUrl: string) {
    http.get(baseUrl + 'api/TeamDetails/'+route.snapshot.paramMap.get('team')).subscribe(result => {
      this.members = result.json() as Array<Person>;
      
      this.team = this.members[0].team;
    }, error => console.error(error));
  }
  add(name: string) {
    var person: Person = new Person();
    person.name = name;
    person.team = this.team;
    this.http.post(this.baseUrl + 'api/TeamDetails', person).subscribe(result => {
      this.members.push(person);
    }, error => console.error(error));
  }
}

interface Team {
  name: string;
  
}

class Person {
  name: string;
  team: Team;
  
}

