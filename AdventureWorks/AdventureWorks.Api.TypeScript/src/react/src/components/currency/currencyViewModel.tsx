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
		this.currencyCode = currencyCode;
this.modifiedDate = modifiedDate;
this.name = name;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>1772a55215eb8a8f62547d195f8f5033</Hash>
</Codenesium>*/