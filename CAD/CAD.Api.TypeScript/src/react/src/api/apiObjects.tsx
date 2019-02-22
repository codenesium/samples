export class ValidationError {
    errorCode: string;
    errorMessage: string;
    propertyName: string;

    constructor () {
        this.errorCode = '';
        this.errorMessage = '';
        this.propertyName = '';
    }
}

export class ActionResponse {
    success: boolean;
    validationErrors: Array<ValidationError>;
    
    constructor () {
        this.success = false;
        this.validationErrors = [];
    }
}

export class CreateResponse<T> extends ActionResponse
{
    record?: T;

    constructor()
    {
        super();
        this.record = undefined;
    }
}

export class UpdateResponse<T> extends ActionResponse
{
    record?: T;

    constructor()
    {
        super();
        this.record = undefined;
    }
}