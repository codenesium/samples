import moment from 'moment'


export default class TableViewModel {
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
    <Hash>59db80d59c3c0ab02f71eac71788ad0e</Hash>
</Codenesium>*/