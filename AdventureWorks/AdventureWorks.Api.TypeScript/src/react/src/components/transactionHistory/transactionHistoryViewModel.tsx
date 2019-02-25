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
    this.productIDNavigation = new ProductViewModel();
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
    this.actualCost = moment(actualCost, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.productID = moment(productID, 'YYYY-MM-DD');
    this.quantity = moment(quantity, 'YYYY-MM-DD');
    this.referenceOrderID = moment(referenceOrderID, 'YYYY-MM-DD');
    this.referenceOrderLineID = moment(referenceOrderLineID, 'YYYY-MM-DD');
    this.transactionDate = moment(transactionDate, 'YYYY-MM-DD');
    this.transactionID = moment(transactionID, 'YYYY-MM-DD');
    this.transactionType = moment(transactionType, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>a653291b6439c02e42ec438840eff948</Hash>
</Codenesium>*/