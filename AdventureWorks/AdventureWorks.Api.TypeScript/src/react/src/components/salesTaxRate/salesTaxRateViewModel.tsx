import moment from 'moment'


export default class SalesTaxRateViewModel {
    modifiedDate:any;
name:string;
rowguid:any;
salesTaxRateID:number;
stateProvinceID:number;
taxRate:number;
taxType:number;

    constructor() {
		this.modifiedDate = undefined;
this.name = '';
this.rowguid = undefined;
this.salesTaxRateID = 0;
this.stateProvinceID = 0;
this.taxRate = 0;
this.taxType = 0;

    }

	setProperties(modifiedDate : any,name : string,rowguid : any,salesTaxRateID : number,stateProvinceID : number,taxRate : number,taxType : number) : void
	{
		this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');
this.salesTaxRateID = moment(salesTaxRateID,'YYYY-MM-DD');
this.stateProvinceID = moment(stateProvinceID,'YYYY-MM-DD');
this.taxRate = moment(taxRate,'YYYY-MM-DD');
this.taxType = moment(taxType,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>39f7640eb77a5dd41fb83e01752923c7</Hash>
</Codenesium>*/