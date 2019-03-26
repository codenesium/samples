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
    this.shipMethodIDNavigation = undefined;
    this.status = 0;
    this.subTotal = 0;
    this.taxAmt = 0;
    this.totalDue = 0;
    this.vendorID = 0;
    this.vendorIDEntity = '';
    this.vendorIDNavigation = undefined;
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
    this.employeeID = employeeID;
    this.freight = freight;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.orderDate = moment(orderDate, 'YYYY-MM-DD');
    this.purchaseOrderID = purchaseOrderID;
    this.revisionNumber = revisionNumber;
    this.shipDate = moment(shipDate, 'YYYY-MM-DD');
    this.shipMethodID = shipMethodID;
    this.status = status;
    this.subTotal = subTotal;
    this.taxAmt = taxAmt;
    this.totalDue = totalDue;
    this.vendorID = vendorID;
  }

  toDisplay(): string {
    return String(this.employeeID);
  }
}


/*<Codenesium>
    <Hash>150271e34b4de79002e4ecc487657578</Hash>
</Codenesium>*/