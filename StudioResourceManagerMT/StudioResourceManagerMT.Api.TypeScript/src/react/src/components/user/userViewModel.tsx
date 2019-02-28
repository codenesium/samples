import moment from 'moment'


export default class UserViewModel {
    id:number;
password:string;
username:string;

    constructor() {
		this.id = 0;
this.password = '';
this.username = '';

    }

	setProperties(id : number,password : string,username : string) : void
	{
		this.id = moment(id,'YYYY-MM-DD');
this.password = moment(password,'YYYY-MM-DD');
this.username = moment(username,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>7448d675351fd0a64fcbc9e7469a8df0</Hash>
</Codenesium>*/