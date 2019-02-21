import moment from 'moment'


export default class CurrencyViewModel {
    currencyCode:string;
modifiedDate:any;
name:string;

    constructor() {
		this.currencyCode = '';
this.modifiedDate = undefined;
this.name = '';

    }

	setProperties(currencyCode : string,modifiedDate : any,name : string) : void
	{
		this.currencyCode = moment(currencyCode,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>f53304f94028f728fd592e864fa0e8d3</Hash>
</Codenesium>*/