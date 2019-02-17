export default class WorkOrderViewModel {
  dueDate: any;
  endDate: any;
  modifiedDate: any;
  orderQty: number;
  productID: number;
  scrappedQty: number;
  scrapReasonID: any;
  startDate: any;
  stockedQty: number;
  workOrderID: number;

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

  setProperties(
    dueDate: any,
    endDate: any,
    modifiedDate: any,
    orderQty: number,
    productID: number,
    scrappedQty: number,
    scrapReasonID: any,
    startDate: any,
    stockedQty: number,
    workOrderID: number
  ): void {
    this.dueDate = dueDate;
    this.endDate = endDate;
    this.modifiedDate = modifiedDate;
    this.orderQty = orderQty;
    this.productID = productID;
    this.scrappedQty = scrappedQty;
    this.scrapReasonID = scrapReasonID;
    this.startDate = startDate;
    this.stockedQty = stockedQty;
    this.workOrderID = workOrderID;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>59d941316da6769b17742d85b91d2948</Hash>
</Codenesium>*/