export default class PhoneNumberTypeViewModel {
    modifiedDate:any;
name:string;
phoneNumberTypeID:number;

    constructor() {
		this.modifiedDate = undefined;
this.name = '';
this.phoneNumberTypeID = 0;

    }

	setProperties(modifiedDate : any,name : string,phoneNumberTypeID : number) : void
	{
		this.modifiedDate = modifiedDate;
this.name = name;
this.phoneNumberTypeID = phoneNumberTypeID;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>88a240bed7d423bed8e8f2aff7c45ea8</Hash>
</Codenesium>*/