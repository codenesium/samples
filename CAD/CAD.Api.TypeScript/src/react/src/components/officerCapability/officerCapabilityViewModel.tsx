import moment from 'moment'


export default class OfficerCapabilityViewModel {
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
    <Hash>dd4fbb1d3dae8fa8ac3445d2f4531f7e</Hash>
</Codenesium>*/