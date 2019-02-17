export default class PasswordViewModel {
    businessEntityID:number;
modifiedDate:any;
passwordHash:string;
passwordSalt:string;
rowguid:any;

    constructor() {
		this.businessEntityID = 0;
this.modifiedDate = undefined;
this.passwordHash = '';
this.passwordSalt = '';
this.rowguid = undefined;

    }

	setProperties(businessEntityID : number,modifiedDate : any,passwordHash : string,passwordSalt : string,rowguid : any) : void
	{
		this.businessEntityID = businessEntityID;
this.modifiedDate = modifiedDate;
this.passwordHash = passwordHash;
this.passwordSalt = passwordSalt;
this.rowguid = rowguid;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>237f18221410cde0c4525a2e915de365</Hash>
</Codenesium>*/