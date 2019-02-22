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
this.name = moment(name,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>b1e969453c62f07c0a28204e4036685f</Hash>
</Codenesium>*/