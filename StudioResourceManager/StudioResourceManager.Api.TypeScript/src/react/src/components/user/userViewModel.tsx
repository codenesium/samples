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
		this.id = id;
this.password = password;
this.username = username;

	}

	toDisplay() : string
	{
		return String(this.username);
	}
};

/*<Codenesium>
    <Hash>c999e6a3df5f3f92d16897a7b94b4254</Hash>
</Codenesium>*/