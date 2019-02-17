export default class CustomerViewModel {
    email:string;
firstName:string;
id:number;
lastName:string;
phone:string;

    constructor() {
		this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';

    }

	setProperties(email : string,firstName : string,id : number,lastName : string,phone : string) : void
	{
		this.email = email;
this.firstName = firstName;
this.id = id;
this.lastName = lastName;
this.phone = phone;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>415d775cf1cdd1b501bcac90d9948cff</Hash>
</Codenesium>*/