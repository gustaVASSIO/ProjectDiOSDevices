import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "@app/services/user.service";

@Injectable()
export default class AuthGuard {
    constructor(private router: Router, private userService: UserService) { }

    canActivate() {
        if (this.userService.verifyUserIsLoged()) {
            return true
        } else {
            this.router.navigate(["/login"])
            return false
        }
    }


}