import { Injectable } from '@angular/core';
import {HttpEvent,HttpInterceptor,HttpHandler,HttpRequest} from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserService } from '@app/services/user.service';


@Injectable()
export class Interceptor implements HttpInterceptor {

    constructor(private userService : UserService){}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = request.clone({
            setHeaders:{
                Authorization : `Bearer ${this.userService.userLoged?.token}`
            }
        })        
        return next.handle(request);
    }
}