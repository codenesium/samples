export default class SalesOrderHeaderViewModel {
  accountNumber: string;
  billToAddressID: number;
  comment: string;
  creditCardApprovalCode: string;
  creditCardID: any;
  creditCardIDEntity: string;
  currencyRateID: any;
  currencyRateIDEntity: string;
  customerID: number;
  customerIDEntity: string;
  dueDate: any;
  freight: number;
  modifiedDate: any;
  onlineOrderFlag: boolean;
  orderDate: any;
  purchaseOrderNumber: string;
  revisionNumber: number;
  rowguid: any;
  salesOrderID: number;
  salesOrderNumber: string;
  salesPersonID: any;
  salesPersonIDEntity: string;
  shipDate: any;
  shipMethodID: number;
  shipToAddressID: number;
  status: number;
  subTotal: number;
  taxAmt: number;
  territoryID: any;
  territoryIDEntity: string;
  totalDue: number;

  constructor() {
    this.accountNumber = '';
    this.billToAddressID = 0;
    this.comment = '';
    this.creditCardApprovalCode = '';
    this.creditCardID = undefined;
    this.creditCardIDEntity = '';
    this.currencyRateID = undefined;
    this.currencyRateIDEntity = '';
    this.customerID = 0;
    this.customerIDEntity = '';
    this.dueDate = undefined;
    this.freight = 0;
    this.modifiedDate = undefined;
    this.onlineOrderFlag = false;
    this.orderDate = undefined;
    this.purchaseOrderNumber = '';
    this.revisionNumber = 0;
    this.rowguid = undefined;
    this.salesOrderID = 0;
    this.salesOrderNumber = '';
    this.salesPersonID = undefined;
    this.salesPersonIDEntity = '';
    this.shipDate = undefined;
    this.shipMethodID = 0;
    this.shipToAddressID = 0;
    this.status = 0;
    this.subTotal = 0;
    this.taxAmt = 0;
    this.territoryID = undefined;
    this.territoryIDEntity = '';
    this.totalDue = 0;
  }

  setProperties(
    accountNumber: string,
    billToAddressID: number,
    comment: string,
    creditCardApprovalCode: string,
    creditCardID: any,
    currencyRateID: any,
    customerID: number,
    dueDate: any,
    freight: number,
    modifiedDate: any,
    onlineOrderFlag: boolean,
    orderDate: any,
    purchaseOrderNumber: string,
    revisionNumber: number,
    rowguid: any,
    salesOrderID: number,
    salesOrderNumber: string,
    salesPersonID: any,
    shipDate: any,
    shipMethodID: number,
    shipToAddressID: number,
    status: number,
    subTotal: number,
    taxAmt: number,
    territoryID: any,
    totalDue: number
  ): void {
    this.accountNumber = accountNumber;
    this.billToAddressID = billToAddressID;
    this.comment = comment;
    this.creditCardApprovalCode = creditCardApprovalCode;
    this.creditCardID = creditCardID;
    this.currencyRateID = currencyRateID;
    this.customerID = customerID;
    this.dueDate = dueDate;
    this.freight = freight;
    this.modifiedDate = modifiedDate;
    this.onlineOrderFlag = onlineOrderFlag;
    this.orderDate = orderDate;
    this.purchaseOrderNumber = purchaseOrderNumber;
    this.revisionNumber = revisionNumber;
    this.rowguid = rowguid;
    this.salesOrderID = salesOrderID;
    this.salesOrderNumber = salesOrderNumber;
    this.salesPersonID = salesPersonID;
    this.shipDate = shipDate;
    this.shipMethodID = shipMethodID;
    this.shipToAddressID = shipToAddressID;
    this.status = status;
    this.subTotal = subTotal;
    this.taxAmt = taxAmt;
    this.territoryID = territoryID;
    this.totalDue = totalDue;
  }
}


/*<Codenesium>
    <Hash>cf89d6054e755d1f75c34af8639e31ba</Hash>
</Codenesium>*/