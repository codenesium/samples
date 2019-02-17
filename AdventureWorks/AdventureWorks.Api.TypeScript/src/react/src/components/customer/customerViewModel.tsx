import StoreViewModel from '../store/storeViewModel'
	import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel'
	

export default class CustomerViewModel {
    accountNumber:string;
customerID:number;
modifiedDate:any;
personID:any;
rowguid:any;
storeID:any;
storeIDEntity : string;
storeIDNavigation? : StoreViewModel;
territoryID:any;
territoryIDEntity : string;
territoryIDNavigation? : SalesTerritoryViewModel;

    constructor() {
		this.accountNumber = '';
this.customerID = 0;
this.modifiedDate = undefined;
this.personID = undefined;
this.rowguid = undefined;
this.storeID = undefined;
this.storeIDEntity = '';
this.storeIDNavigation = undefined;
this.territoryID = undefined;
this.territoryIDEntity = '';
this.territoryIDNavigation = undefined;

    }

	setProperties(accountNumber : string,customerID : number,modifiedDate : any,personID : any,rowguid : any,storeID : any,territoryID : any) : void
	{
		this.accountNumber = accountNumber;
this.customerID = customerID;
this.modifiedDate = modifiedDate;
this.personID = personID;
this.rowguid = rowguid;
this.storeID = storeID;
this.territoryID = territoryID;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>ba227ce47cbb1189df8f542fb0a9334e</Hash>
</Codenesium>*/