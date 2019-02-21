export default class CustomerViewModel {
    email:string;
firstName:string;
id:number;
lastName:string;
note:string;
phone:string;

    constructor() {
		this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.note = '';
this.phone = '';

    }

	setProperties(email : string,firstName : string,id : number,lastName : string,note : string,phone : string) : void
	{
		this.email = email;
this.firstName = firstName;
this.id = id;
this.lastName = lastName;
this.note = note;
this.phone = phone;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>e0435d12fe2f1f7807d87a993503a211</Hash>
</Codenesium>*/