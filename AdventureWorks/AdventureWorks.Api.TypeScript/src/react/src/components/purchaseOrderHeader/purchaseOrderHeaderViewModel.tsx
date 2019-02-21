import moment from 'moment'


export default class PurchaseOrderHeaderViewModel {
    employeeID:number;
freight:number;
modifiedDate:any;
orderDate:any;
purchaseOrderID:number;
revisionNumber:number;
shipDate:any;
shipMethodID:number;
status:number;
subTotal:number;
taxAmt:number;
totalDue:number;
vendorID:number;

    constructor() {
		this.employeeID = 0;
this.freight = 0;
this.modifiedDate = undefined;
this.orderDate = undefined;
this.purchaseOrderID = 0;
this.revisionNumber = 0;
this.shipDate = undefined;
this.shipMethodID = 0;
this.status = 0;
this.subTotal = 0;
this.taxAmt = 0;
this.totalDue = 0;
this.vendorID = 0;

    }

	setProperties(employeeID : number,freight : number,modifiedDate : any,orderDate : any,purchaseOrderID : number,revisionNumber : number,shipDate : any,shipMethodID : number,status : number,subTotal : number,taxAmt : number,totalDue : number,vendorID : number) : void
	{
		this.employeeID = moment(employeeID,'YYYY-MM-DD');
this.freight = moment(freight,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.orderDate = moment(orderDate,'YYYY-MM-DD');
this.purchaseOrderID = moment(purchaseOrderID,'YYYY-MM-DD');
this.revisionNumber = moment(revisionNumber,'YYYY-MM-DD');
this.shipDate = moment(shipDate,'YYYY-MM-DD');
this.shipMethodID = moment(shipMethodID,'YYYY-MM-DD');
this.status = moment(status,'YYYY-MM-DD');
this.subTotal = moment(subTotal,'YYYY-MM-DD');
this.taxAmt = moment(taxAmt,'YYYY-MM-DD');
this.totalDue = moment(totalDue,'YYYY-MM-DD');
this.vendorID = moment(vendorID,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>66932e70831d4d2a7d130a411ffecf6a</Hash>
</Codenesium>*/