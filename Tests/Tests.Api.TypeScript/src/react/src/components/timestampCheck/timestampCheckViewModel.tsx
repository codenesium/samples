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
    <Hash>ccc759c1512bf96f9a1471f9c7cf76cc</Hash>
</Codenesium>*/