import { UserService } from './../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserLogin } from '@app/models/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public formLogin: FormGroup = new FormGroup({
    username: new FormControl(undefined, [Validators.required]),
    password: new FormControl(undefined, [Validators.required]),
  })

  constructor(
    private readonly userService: UserService,
    private readonly router : Router
    ) { }

  ngOnInit(): void {

  }
  confirmLogin() {
    const user: UserLogin = this.formLogin.value
    console.log(user);

    this.userService.login(user).subscribe((userToken) => {
      console.log(userToken);

      localStorage.setItem("user", JSON.stringify(userToken))
      this.userService.userLoged = userToken
      this.router.navigate(['/admin/'])
    })
  }

}
