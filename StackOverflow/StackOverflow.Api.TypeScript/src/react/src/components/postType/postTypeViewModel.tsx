import moment from 'moment'


export default class PostTypeViewModel {
    id:number;
rwType:string;

    constructor() {
		this.id = 0;
this.rwType = '';

    }

	setProperties(id : number,rwType : string) : void
	{
		this.id = id;
this.rwType = rwType;

	}

	toDisplay() : string
	{
		return String(this.rwType);
	}
};

/*<Codenesium>
    <Hash>7fb4447702012f1742f9c5a40903e2c6</Hash>
</Codenesium>*/