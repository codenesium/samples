import moment from 'moment'


export default class CallTypeViewModel {
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
		return String(this.id);
	}
};

/*<Codenesium>
    <Hash>f9cd3f8c8e4d685a9ef61a73826cce5d</Hash>
</Codenesium>*/