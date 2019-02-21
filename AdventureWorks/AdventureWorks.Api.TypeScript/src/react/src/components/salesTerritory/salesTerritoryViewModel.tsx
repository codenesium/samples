import moment from 'moment'


export default class SalesTerritoryViewModel {
    costLastYear:number;
costYTD:number;
countryRegionCode:string;
modifiedDate:any;
name:string;
rowguid:any;
salesLastYear:number;
salesYTD:number;
territoryID:number;

    constructor() {
		this.costLastYear = 0;
this.costYTD = 0;
this.countryRegionCode = '';
this.modifiedDate = undefined;
this.name = '';
this.rowguid = undefined;
this.salesLastYear = 0;
this.salesYTD = 0;
this.territoryID = 0;

    }

	setProperties(costLastYear : number,costYTD : number,countryRegionCode : string,modifiedDate : any,name : string,rowguid : any,salesLastYear : number,salesYTD : number,territoryID : number) : void
	{
		this.costLastYear = moment(costLastYear,'YYYY-MM-DD');
this.costYTD = moment(costYTD,'YYYY-MM-DD');
this.countryRegionCode = moment(countryRegionCode,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');
this.salesLastYear = moment(salesLastYear,'YYYY-MM-DD');
this.salesYTD = moment(salesYTD,'YYYY-MM-DD');
this.territoryID = moment(territoryID,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>06d2da2b120f796daac942314012970a</Hash>
</Codenesium>*/