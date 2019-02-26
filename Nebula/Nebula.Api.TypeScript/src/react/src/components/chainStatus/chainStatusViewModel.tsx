import moment from 'moment'


export default class ChainStatusViewModel {
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
    <Hash>8e2f52cd2c4e49a3c9559b2d1debdae4</Hash>
</Codenesium>*/