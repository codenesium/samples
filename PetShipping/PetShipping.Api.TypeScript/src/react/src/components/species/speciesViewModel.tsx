import moment from 'moment'


export default class SpeciesViewModel {
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
    <Hash>3b971f13caadb9602a757d373a03a3a5</Hash>
</Codenesium>*/