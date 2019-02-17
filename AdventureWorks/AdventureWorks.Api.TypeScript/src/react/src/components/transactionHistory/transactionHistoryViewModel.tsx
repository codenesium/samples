export default class TransactionHistoryViewModel {
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
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.quantity = quantity;
    this.referenceOrderID = referenceOrderID;
    this.referenceOrderLineID = referenceOrderLineID;
    this.transactionDate = transactionDate;
    this.transactionID = transactionID;
    this.transactionType = transactionType;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>5ae79354ffec6a6a74d1a4df2222750b</Hash>
</Codenesium>*/