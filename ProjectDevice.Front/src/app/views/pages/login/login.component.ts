import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { UserService } from './../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserLogin } from '@app/models/user.model';
import Message from '@app/shared/message';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers:[MessageService]
})
export class LoginComponent implements OnInit {

  private readonly message: Message
  public formLogin: FormGroup = new FormGroup({
    username: new FormControl(undefined, [Validators.required]),
    password: new FormControl(undefined, [Validators.required]),
  })

  constructor(
    private readonly userService: UserService,
    private readonly messageService : MessageService,
    private readonly router : Router
    ) { 
      this.message = new Message(messageService, router)
    }

  ngOnInit(): void {

  }
  confirmLogin() {
    const user: UserLogin = this.formLogin.value
    this.userService.login(user).subscribe({
      next:(userToken) => {
      
      localStorage.setItem("user", JSON.stringify(userToken))
      
      this.userService.userLoged = userToken
      this.router.navigate(['/admin/'])
    },
    error:(error : HttpErrorResponse)=>{
      console.log(error);
      
      switch (error.status) {
        case 400:
          this.message.messageError(error.error)
          break;
      
        default:
          this.message.messageError("Something goes wrong, try again")
          break;
      }
      
    }
  })
  }

}
