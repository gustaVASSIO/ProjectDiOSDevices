import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private readonly router : Router){}
  
  ngOnInit(): void {  
    this.router.events.subscribe(event => {
    if (event instanceof NavigationEnd) {
    if (document.getElementById("frok_js") != null) {
    document.getElementById("frok_js")?.remove();
    }
    const scriptTag = document.createElement("script");
    scriptTag.src = "content/frok/frontend-kit.js";
    scriptTag.id = "frok_js";
    document.body.appendChild(scriptTag);
    }
  
    });
  }
}
