import moment from 'moment'


export default class CountryViewModel {
    id:number;
name:string;

    constructor() {
		this.id = 0;
this.name = '';

    }

	setProperties(id : number,name : string) : void
	{
		this.id = moment(id,'YYYY-MM-DD');
this.name = name;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>27546691946945615627cac1b63278ec</Hash>
</Codenesium>*/