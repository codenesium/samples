import moment from 'moment'


export default class AdminViewModel {
    birthday:any;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;

    constructor() {
		this.birthday = undefined;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;

    }

	setProperties(birthday : any,email : string,firstName : string,id : number,lastName : string,phone : string,userId : number) : void
	{
		this.birthday = moment(birthday,'YYYY-MM-DD');
this.email = moment(email,'YYYY-MM-DD');
this.firstName = moment(firstName,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.lastName = moment(lastName,'YYYY-MM-DD');
this.phone = moment(phone,'YYYY-MM-DD');
this.userId = moment(userId,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>9f50169d2c73b4077b6a112958c6a693</Hash>
</Codenesium>*/