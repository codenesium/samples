import moment from 'moment'


export default class VehicleViewModel {
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
    <Hash>0655ef76a06707f0cbf2f772c2b69b31</Hash>
</Codenesium>*/