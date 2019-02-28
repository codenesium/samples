import moment from 'moment'


export default class TeacherViewModel {
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
    <Hash>1bd127b64a46963e99a623dfd091f273</Hash>
</Codenesium>*/