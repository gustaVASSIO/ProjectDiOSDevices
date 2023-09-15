import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLogin, UserToken } from '@app/models/user.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class UserService {

    private _userLoged?: UserToken | undefined;

    public get userLoged(): UserToken | undefined {
        return this._userLoged;
    }

    public set userLoged(value: UserToken | undefined) {
        this._userLoged = value;
    }

    constructor(
        private router: Router,
        private http: HttpClient
    ) { }

    public login(user: UserLogin): Observable<UserToken> {
        return this.http.post<UserToken>(`${environment.API}/Auth/Login`, user)
    }

    public logout(): void {
        localStorage.removeItem("user")
        this.router.navigate(["/"])
        this.userLoged = undefined
    }

    public verifyUserIsLoged(): boolean {
        const userStorage: UserToken = JSON.parse(localStorage.getItem("user")!)
        if (userStorage != null) {
            this.userLoged = userStorage
            return true
        } else {
            return false
        }

    }

}
