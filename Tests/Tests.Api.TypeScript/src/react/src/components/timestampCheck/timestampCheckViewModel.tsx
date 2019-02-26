import moment from 'moment'


export default class TimestampCheckViewModel {
    id:number;
name:string;
timestamp:any;

    constructor() {
		this.id = 0;
this.name = '';
this.timestamp = undefined;

    }

	setProperties(id : number,name : string,timestamp : any) : void
	{
		this.id = id;
this.name = name;
this.timestamp = timestamp;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>d7173a3fbbcd6632c6d4191281b8064a</Hash>
</Codenesium>*/