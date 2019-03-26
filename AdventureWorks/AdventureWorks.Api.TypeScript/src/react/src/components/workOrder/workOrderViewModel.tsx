import moment from 'moment';
import ProductViewModel from '../product/productViewModel';
import ScrapReasonViewModel from '../scrapReason/scrapReasonViewModel';

export default class WorkOrderViewModel {
  dueDate: any;
  endDate: any;
  modifiedDate: any;
  orderQty: number;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductViewModel;
  scrappedQty: number;
  scrapReasonID: number;
  scrapReasonIDEntity: string;
  scrapReasonIDNavigation?: ScrapReasonViewModel;
  startDate: any;
  stockedQty: number;
  workOrderID: number;

  constructor() {
    this.dueDate = undefined;
    this.endDate = undefined;
    this.modifiedDate = undefined;
    this.orderQty = 0;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.scrappedQty = 0;
    this.scrapReasonID = 0;
    this.scrapReasonIDEntity = '';
    this.scrapReasonIDNavigation = undefined;
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
    scrapReasonID: number,
    startDate: any,
    stockedQty: number,
    workOrderID: number
  ): void {
    this.dueDate = moment(dueDate, 'YYYY-MM-DD');
    this.endDate = moment(endDate, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.orderQty = orderQty;
    this.productID = productID;
    this.scrappedQty = scrappedQty;
    this.scrapReasonID = scrapReasonID;
    this.startDate = moment(startDate, 'YYYY-MM-DD');
    this.stockedQty = stockedQty;
    this.workOrderID = workOrderID;
  }

  toDisplay(): string {
    return String(this.dueDate);
  }
}


/*<Codenesium>
    <Hash>3ecff22c673cf83fd758c64dd852a0ce</Hash>
</Codenesium>*/