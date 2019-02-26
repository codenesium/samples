import moment from 'moment'
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
this.storeIDNavigation = new StoreViewModel();
this.territoryID = undefined;
this.territoryIDEntity = '';
this.territoryIDNavigation = new SalesTerritoryViewModel();

    }

	setProperties(accountNumber : string,customerID : number,modifiedDate : any,personID : any,rowguid : any,storeID : any,territoryID : any) : void
	{
		this.accountNumber = moment(accountNumber,'YYYY-MM-DD');
this.customerID = moment(customerID,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.personID = moment(personID,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');
this.storeID = moment(storeID,'YYYY-MM-DD');
this.territoryID = moment(territoryID,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>0e34f906feba2d5f02d9a0c9d4a41eb1</Hash>
</Codenesium>*/