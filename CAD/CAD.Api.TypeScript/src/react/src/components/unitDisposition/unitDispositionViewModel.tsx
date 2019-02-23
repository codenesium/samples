import moment from 'moment'


export default class UnitDispositionViewModel {
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
    <Hash>e9a54770c18113f3da5d56ad02f79cd2</Hash>
</Codenesium>*/