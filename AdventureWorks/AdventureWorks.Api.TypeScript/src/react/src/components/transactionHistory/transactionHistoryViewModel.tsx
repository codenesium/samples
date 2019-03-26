import moment from 'moment';
import ProductViewModel from '../product/productViewModel';

export default class TransactionHistoryViewModel {
  actualCost: number;
  modifiedDate: any;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductViewModel;
  quantity: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: any;
  transactionID: number;
  transactionType: string;

  constructor() {
    this.actualCost = 0;
    this.modifiedDate = undefined;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.quantity = 0;
    this.referenceOrderID = 0;
    this.referenceOrderLineID = 0;
    this.transactionDate = undefined;
    this.transactionID = 0;
    this.transactionType = '';
  }

  setProperties(
    actualCost: number,
    modifiedDate: any,
    productID: number,
    quantity: number,
    referenceOrderID: number,
    referenceOrderLineID: number,
    transactionDate: any,
    transactionID: number,
    transactionType: string
  ): void {
    this.actualCost = actualCost;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.productID = productID;
    this.quantity = quantity;
    this.referenceOrderID = referenceOrderID;
    this.referenceOrderLineID = referenceOrderLineID;
    this.transactionDate = moment(transactionDate, 'YYYY-MM-DD');
    this.transactionID = transactionID;
    this.transactionType = transactionType;
  }

  toDisplay(): string {
    return String(this.actualCost);
  }
}


/*<Codenesium>
    <Hash>bd6399dbef1046249c1ada9ffea4d5cc</Hash>
</Codenesium>*/