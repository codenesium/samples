import CurrencyViewModel from '../currency/currencyViewModel'
	import CurrencyViewModel from '../currency/currencyViewModel'
	

export default class CurrencyRateViewModel {
    averageRate:number;
currencyRateDate:any;
currencyRateID:number;
endOfDayRate:number;
fromCurrencyCode:string;
fromCurrencyCodeEntity : string;
fromCurrencyCodeNavigation? : CurrencyViewModel;
modifiedDate:any;
toCurrencyCode:string;
toCurrencyCodeEntity : string;
toCurrencyCodeNavigation? : CurrencyViewModel;

    constructor() {
		this.averageRate = 0;
this.currencyRateDate = undefined;
this.currencyRateID = 0;
this.endOfDayRate = 0;
this.fromCurrencyCode = '';
this.fromCurrencyCodeEntity = '';
this.fromCurrencyCodeNavigation = undefined;
this.modifiedDate = undefined;
this.toCurrencyCode = '';
this.toCurrencyCodeEntity = '';
this.toCurrencyCodeNavigation = undefined;

    }

	setProperties(averageRate : number,currencyRateDate : any,currencyRateID : number,endOfDayRate : number,fromCurrencyCode : string,modifiedDate : any,toCurrencyCode : string) : void
	{
		this.averageRate = averageRate;
this.currencyRateDate = currencyRateDate;
this.currencyRateID = currencyRateID;
this.endOfDayRate = endOfDayRate;
this.fromCurrencyCode = fromCurrencyCode;
this.modifiedDate = modifiedDate;
this.toCurrencyCode = toCurrencyCode;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>5afe857e7870a6b0884c18528f2a5180</Hash>
</Codenesium>*/