import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(
    public readonly userService : UserService
    ){}
  
  ngOnInit(): void {  
    this.userService.verifyUserIsLoged()
  }
}
