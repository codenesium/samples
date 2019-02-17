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
		this.employeeID = employeeID;
this.freight = freight;
this.modifiedDate = modifiedDate;
this.orderDate = orderDate;
this.purchaseOrderID = purchaseOrderID;
this.revisionNumber = revisionNumber;
this.shipDate = shipDate;
this.shipMethodID = shipMethodID;
this.status = status;
this.subTotal = subTotal;
this.taxAmt = taxAmt;
this.totalDue = totalDue;
this.vendorID = vendorID;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>4f67e4cd81783072c34252e07c4d513d</Hash>
</Codenesium>*/