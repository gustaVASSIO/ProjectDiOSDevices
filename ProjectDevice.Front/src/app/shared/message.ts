import { Router } from "@angular/router";
import {  MessageService } from "primeng/api";

export default class Message{
    constructor(
        private messageService : MessageService,
        private router : Router,
    ) {}
    public messageSuccess(summary : string, detail : string = '', duration : number = 1300){
        this.messageService.add({key:'success', severity:'success', summary, detail, life: duration})
    }
    public messageError(summary : string, detail : string = '', duration : number = 1300){
        this.messageService.add({key:'error', severity:'error', summary, detail, life: duration})
    }
    public redirect(redirectTo : string = ''){
        this.router.navigate(['/' + redirectTo])
    }
}