import moment from 'moment'


export default class AdminViewModel {
    email:string;
firstName:string;
id:number;
lastName:string;
password:string;
phone:string;
username:string;

    constructor() {
		this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.password = '';
this.phone = '';
this.username = '';

    }

	setProperties(email : string,firstName : string,id : number,lastName : string,password : string,phone : string,username : string) : void
	{
		this.email = email;
this.firstName = firstName;
this.id = moment(id,'YYYY-MM-DD');
this.lastName = lastName;
this.password = password;
this.phone = phone;
this.username = username;

	}

	toDisplay() : string
	{
		return String(this.username);
	}
};

/*<Codenesium>
    <Hash>260d14da42be79e94ae043a60d422615</Hash>
</Codenesium>*/