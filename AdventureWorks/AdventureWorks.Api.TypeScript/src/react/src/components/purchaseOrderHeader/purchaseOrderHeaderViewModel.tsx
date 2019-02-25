import moment from 'moment';
import ShipMethodViewModel from '../shipMethod/shipMethodViewModel';
import VendorViewModel from '../vendor/vendorViewModel';

export default class PurchaseOrderHeaderViewModel {
  employeeID: number;
  freight: number;
  modifiedDate: any;
  orderDate: any;
  purchaseOrderID: number;
  revisionNumber: number;
  shipDate: any;
  shipMethodID: number;
  shipMethodIDEntity: string;
  shipMethodIDNavigation?: ShipMethodViewModel;
  status: number;
  subTotal: number;
  taxAmt: number;
  totalDue: number;
  vendorID: number;
  vendorIDEntity: string;
  vendorIDNavigation?: VendorViewModel;

  constructor() {
    this.employeeID = 0;
    this.freight = 0;
    this.modifiedDate = undefined;
    this.orderDate = undefined;
    this.purchaseOrderID = 0;
    this.revisionNumber = 0;
    this.shipDate = undefined;
    this.shipMethodID = 0;
    this.shipMethodIDEntity = '';
    this.shipMethodIDNavigation = new ShipMethodViewModel();
    this.status = 0;
    this.subTotal = 0;
    this.taxAmt = 0;
    this.totalDue = 0;
    this.vendorID = 0;
    this.vendorIDEntity = '';
    this.vendorIDNavigation = new VendorViewModel();
  }

  setProperties(
    employeeID: number,
    freight: number,
    modifiedDate: any,
    orderDate: any,
    purchaseOrderID: number,
    revisionNumber: number,
    shipDate: any,
    shipMethodID: number,
    status: number,
    subTotal: number,
    taxAmt: number,
    totalDue: number,
    vendorID: number
  ): void {
    this.employeeID = moment(employeeID, 'YYYY-MM-DD');
    this.freight = moment(freight, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.orderDate = moment(orderDate, 'YYYY-MM-DD');
    this.purchaseOrderID = moment(purchaseOrderID, 'YYYY-MM-DD');
    this.revisionNumber = moment(revisionNumber, 'YYYY-MM-DD');
    this.shipDate = moment(shipDate, 'YYYY-MM-DD');
    this.shipMethodID = moment(shipMethodID, 'YYYY-MM-DD');
    this.status = moment(status, 'YYYY-MM-DD');
    this.subTotal = moment(subTotal, 'YYYY-MM-DD');
    this.taxAmt = moment(taxAmt, 'YYYY-MM-DD');
    this.totalDue = moment(totalDue, 'YYYY-MM-DD');
    this.vendorID = moment(vendorID, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>e145b306ed7d4b9410891d2cab299237</Hash>
</Codenesium>*/