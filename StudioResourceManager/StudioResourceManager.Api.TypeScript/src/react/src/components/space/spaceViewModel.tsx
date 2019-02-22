import moment from 'moment'


export default class SpaceViewModel {
    description:string;
id:number;
name:string;

    constructor() {
		this.description = '';
this.id = 0;
this.name = '';

    }

	setProperties(description : string,id : number,name : string) : void
	{
		this.description = description;
this.id = moment(id,'YYYY-MM-DD');
this.name = name;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>ad5c4edcc8c4268e1d3f61fbee236f1f</Hash>
</Codenesium>*/