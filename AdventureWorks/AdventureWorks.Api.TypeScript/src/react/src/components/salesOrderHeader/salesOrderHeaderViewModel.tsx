import moment from 'moment'
import CreditCardViewModel from '../creditCard/creditCardViewModel'
	import CurrencyRateViewModel from '../currencyRate/currencyRateViewModel'
	import CustomerViewModel from '../customer/customerViewModel'
	import SalesPersonViewModel from '../salesPerson/salesPersonViewModel'
	import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel'
	

export default class SalesOrderHeaderViewModel {
    accountNumber:string;
billToAddressID:number;
comment:string;
creditCardApprovalCode:string;
creditCardID:any;
creditCardIDEntity : string;
creditCardIDNavigation? : CreditCardViewModel;
currencyRateID:any;
currencyRateIDEntity : string;
currencyRateIDNavigation? : CurrencyRateViewModel;
customerID:number;
customerIDEntity : string;
customerIDNavigation? : CustomerViewModel;
dueDate:any;
freight:number;
modifiedDate:any;
onlineOrderFlag:boolean;
orderDate:any;
purchaseOrderNumber:string;
revisionNumber:number;
rowguid:any;
salesOrderID:number;
salesOrderNumber:string;
salesPersonID:any;
salesPersonIDEntity : string;
salesPersonIDNavigation? : SalesPersonViewModel;
shipDate:any;
shipMethodID:number;
shipToAddressID:number;
status:number;
subTotal:number;
taxAmt:number;
territoryID:any;
territoryIDEntity : string;
territoryIDNavigation? : SalesTerritoryViewModel;
totalDue:number;

    constructor() {
		this.accountNumber = '';
this.billToAddressID = 0;
this.comment = '';
this.creditCardApprovalCode = '';
this.creditCardID = undefined;
this.creditCardIDEntity = '';
this.creditCardIDNavigation = new CreditCardViewModel();
this.currencyRateID = undefined;
this.currencyRateIDEntity = '';
this.currencyRateIDNavigation = new CurrencyRateViewModel();
this.customerID = 0;
this.customerIDEntity = '';
this.customerIDNavigation = new CustomerViewModel();
this.dueDate = undefined;
this.freight = 0;
this.modifiedDate = undefined;
this.onlineOrderFlag = false;
this.orderDate = undefined;
this.purchaseOrderNumber = '';
this.revisionNumber = 0;
this.rowguid = undefined;
this.salesOrderID = 0;
this.salesOrderNumber = '';
this.salesPersonID = undefined;
this.salesPersonIDEntity = '';
this.salesPersonIDNavigation = new SalesPersonViewModel();
this.shipDate = undefined;
this.shipMethodID = 0;
this.shipToAddressID = 0;
this.status = 0;
this.subTotal = 0;
this.taxAmt = 0;
this.territoryID = undefined;
this.territoryIDEntity = '';
this.territoryIDNavigation = new SalesTerritoryViewModel();
this.totalDue = 0;

    }

	setProperties(accountNumber : string,billToAddressID : number,comment : string,creditCardApprovalCode : string,creditCardID : any,currencyRateID : any,customerID : number,dueDate : any,freight : number,modifiedDate : any,onlineOrderFlag : boolean,orderDate : any,purchaseOrderNumber : string,revisionNumber : number,rowguid : any,salesOrderID : number,salesOrderNumber : string,salesPersonID : any,shipDate : any,shipMethodID : number,shipToAddressID : number,status : number,subTotal : number,taxAmt : number,territoryID : any,totalDue : number) : void
	{
		this.accountNumber = moment(accountNumber,'YYYY-MM-DD');
this.billToAddressID = moment(billToAddressID,'YYYY-MM-DD');
this.comment = moment(comment,'YYYY-MM-DD');
this.creditCardApprovalCode = moment(creditCardApprovalCode,'YYYY-MM-DD');
this.creditCardID = moment(creditCardID,'YYYY-MM-DD');
this.currencyRateID = moment(currencyRateID,'YYYY-MM-DD');
this.customerID = moment(customerID,'YYYY-MM-DD');
this.dueDate = moment(dueDate,'YYYY-MM-DD');
this.freight = moment(freight,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.onlineOrderFlag = moment(onlineOrderFlag,'YYYY-MM-DD');
this.orderDate = moment(orderDate,'YYYY-MM-DD');
this.purchaseOrderNumber = moment(purchaseOrderNumber,'YYYY-MM-DD');
this.revisionNumber = moment(revisionNumber,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');
this.salesOrderID = moment(salesOrderID,'YYYY-MM-DD');
this.salesOrderNumber = moment(salesOrderNumber,'YYYY-MM-DD');
this.salesPersonID = moment(salesPersonID,'YYYY-MM-DD');
this.shipDate = moment(shipDate,'YYYY-MM-DD');
this.shipMethodID = moment(shipMethodID,'YYYY-MM-DD');
this.shipToAddressID = moment(shipToAddressID,'YYYY-MM-DD');
this.status = moment(status,'YYYY-MM-DD');
this.subTotal = moment(subTotal,'YYYY-MM-DD');
this.taxAmt = moment(taxAmt,'YYYY-MM-DD');
this.territoryID = moment(territoryID,'YYYY-MM-DD');
this.totalDue = moment(totalDue,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>eeb94f2b2bd9dfe35f28b34f5537182e</Hash>
</Codenesium>*/