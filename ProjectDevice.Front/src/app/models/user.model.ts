export interface UserLogin{
    username: string,
    password: string,
}

export interface UserToken{
    userId : string,
    authenticated : boolean,
    token : string,
    userName : string,
    role : string,
}