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
		return String();
	}
};

/*<Codenesium>
    <Hash>9c2954998bd834a91108cb8a6cc80436</Hash>
</Codenesium>*/