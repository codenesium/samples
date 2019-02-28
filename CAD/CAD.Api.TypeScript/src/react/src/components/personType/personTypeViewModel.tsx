import moment from 'moment'


export default class PersonTypeViewModel {
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
    <Hash>f661f44f5789b5048cf8be63b3b8c463</Hash>
</Codenesium>*/