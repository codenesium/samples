import moment from 'moment'


export default class SpaceFeatureViewModel {
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
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>85c88f4d670e3f4b362327badf00f80e</Hash>
</Codenesium>*/