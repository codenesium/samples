import moment from 'moment'


export default class VehicleCapabilityViewModel {
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
    <Hash>8c347d74d40067f394a8ca26d374f6c1</Hash>
</Codenesium>*/