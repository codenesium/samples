import moment from 'moment'


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
		this.email = moment(email,'YYYY-MM-DD');
this.firstName = moment(firstName,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.lastName = moment(lastName,'YYYY-MM-DD');
this.note = moment(note,'YYYY-MM-DD');
this.phone = moment(phone,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>ac5126eea06d46899a3074c88bccaa99</Hash>
</Codenesium>*/