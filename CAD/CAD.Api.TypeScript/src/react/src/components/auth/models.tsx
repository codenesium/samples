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

export class ChangePasswordClientRequestModel {
    currentPassword:string;
    newPassword:string;

    constructor() {
        this.currentPassword = '';
        this.newPassword = '';
    }

    setProperties(currentPassword:string, newPassword:string) : void
    {
        this.currentPassword = currentPassword;
        this.newPassword = newPassword;
    }
}

export class ChangeEmailClientRequestModel {
    password:string;
    newEmail:string;

    constructor() {
        this.password = '';
        this.newEmail = '';
    }

    setProperties(password:string, newEmail:string) : void
    {
        this.password = password;
        this.newEmail = newEmail;
    }
}

export class ConfirmChangeEmailClientRequestModel {
    token:string;
    newEmail:string;

    constructor() {
        this.token = '';
        this.newEmail = '';
    }

    setProperties(token:string, newEmail:string) : void
    {
        this.token = token;
        this.newEmail = newEmail;
    }
}