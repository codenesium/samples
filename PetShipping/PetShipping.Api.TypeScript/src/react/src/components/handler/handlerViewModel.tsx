import moment from 'moment'


export default class HandlerViewModel {
    countryId:number;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;

    constructor() {
		this.countryId = 0;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';

    }

	setProperties(countryId : number,email : string,firstName : string,id : number,lastName : string,phone : string) : void
	{
		this.countryId = countryId;
this.email = email;
this.firstName = firstName;
this.id = id;
this.lastName = lastName;
this.phone = phone;

	}

	toDisplay() : string
	{
		return String(this.countryId);
	}
};

/*<Codenesium>
    <Hash>427665274874e4df879de443b0bfd9b9</Hash>
</Codenesium>*/