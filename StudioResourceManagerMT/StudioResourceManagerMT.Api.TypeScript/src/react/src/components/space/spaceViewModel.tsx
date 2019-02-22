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
		this.description = moment(description,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>4f7d37d5b6dd8d0cb97164ccdaef3305</Hash>
</Codenesium>*/