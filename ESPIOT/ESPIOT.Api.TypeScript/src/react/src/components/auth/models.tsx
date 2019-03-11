export class LoginClientRequestModel {
    email:string;
    password:string;



    constructor() {
        this.email = '';
        this.password = '';
    }

    setProperties(email:string, password:string ) : void
    {
        this.email = email;
        this.password = password;
    }
}

export class RegisterClientRequestModel {
    email:string;
    password:string;



    constructor() {
        this.email = '';
        this.password = '';
    }

    setProperties(email:string, password:string ) : void
    {
        this.email = email;
        this.password = password;
    }
}

export class ResetPasswordClientRequestModel {
    email:string;

    constructor() {
        this.email = '';
    }

    setProperties(email:string) : void
    {
        this.email = email;
    }
}