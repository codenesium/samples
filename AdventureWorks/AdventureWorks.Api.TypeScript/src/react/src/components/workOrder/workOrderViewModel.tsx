import moment from 'moment'


export default class WorkOrderViewModel {
    dueDate:any;
endDate:any;
modifiedDate:any;
orderQty:number;
productID:number;
scrappedQty:number;
scrapReasonID:any;
startDate:any;
stockedQty:number;
workOrderID:number;

    constructor() {
		this.dueDate = undefined;
this.endDate = undefined;
this.modifiedDate = undefined;
this.orderQty = 0;
this.productID = 0;
this.scrappedQty = 0;
this.scrapReasonID = undefined;
this.startDate = undefined;
this.stockedQty = 0;
this.workOrderID = 0;

    }

	setProperties(dueDate : any,endDate : any,modifiedDate : any,orderQty : number,productID : number,scrappedQty : number,scrapReasonID : any,startDate : any,stockedQty : number,workOrderID : number) : void
	{
		this.dueDate = moment(dueDate,'YYYY-MM-DD');
this.endDate = moment(endDate,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.orderQty = moment(orderQty,'YYYY-MM-DD');
this.productID = moment(productID,'YYYY-MM-DD');
this.scrappedQty = moment(scrappedQty,'YYYY-MM-DD');
this.scrapReasonID = moment(scrapReasonID,'YYYY-MM-DD');
this.startDate = moment(startDate,'YYYY-MM-DD');
this.stockedQty = moment(stockedQty,'YYYY-MM-DD');
this.workOrderID = moment(workOrderID,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>4f43a446efc7c36083140400c7c4ddbc</Hash>
</Codenesium>*/