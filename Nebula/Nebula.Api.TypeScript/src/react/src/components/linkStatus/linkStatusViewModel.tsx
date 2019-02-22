import moment from 'moment'


export default class LinkStatusViewModel {
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
    <Hash>79fb3641e8b50aacf21bcd54a8b1f466</Hash>
</Codenesium>*/