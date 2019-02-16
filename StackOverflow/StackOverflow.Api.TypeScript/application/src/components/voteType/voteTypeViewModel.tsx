export default class VoteTypeViewModel {
    id:number;
name:string;

    constructor() {
		this.id = 0;
this.name = '';

    }

	setProperties(id : number,name : string) : void
	{
		this.id = id;
this.name = name;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>9a0c354aed057f2f055627cd2cf301d2</Hash>
</Codenesium>*/