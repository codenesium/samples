import moment from 'moment';

export default class TransactionHistoryArchiveViewModel {
  actualCost: number;
  modifiedDate: any;
  productID: number;
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
    <Hash>2300587fb2d60fc1b3be2a52114abfcd</Hash>
</Codenesium>*/