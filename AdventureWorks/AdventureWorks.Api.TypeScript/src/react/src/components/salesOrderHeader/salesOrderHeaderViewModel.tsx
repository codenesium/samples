import moment from 'moment';
import CreditCardViewModel from '../creditCard/creditCardViewModel';
import CurrencyRateViewModel from '../currencyRate/currencyRateViewModel';
import CustomerViewModel from '../customer/customerViewModel';
import SalesPersonViewModel from '../salesPerson/salesPersonViewModel';
import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel';

export default class SalesOrderHeaderViewModel {
  accountNumber: string;
  billToAddressID: number;
  comment: string;
  creditCardApprovalCode: string;
  creditCardID: number;
  creditCardIDEntity: string;
  creditCardIDNavigation?: CreditCardViewModel;
  currencyRateID: number;
  currencyRateIDEntity: string;
  currencyRateIDNavigation?: CurrencyRateViewModel;
  customerID: number;
  customerIDEntity: string;
  customerIDNavigation?: CustomerViewModel;
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
  salesPersonID: number;
  salesPersonIDEntity: string;
  salesPersonIDNavigation?: SalesPersonViewModel;
  shipDate: any;
  shipMethodID: number;
  shipToAddressID: number;
  status: number;
  subTotal: number;
  taxAmt: number;
  territoryID: number;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryViewModel;
  totalDue: number;

  constructor() {
    this.accountNumber = '';
    this.billToAddressID = 0;
    this.comment = '';
    this.creditCardApprovalCode = '';
    this.creditCardID = 0;
    this.creditCardIDEntity = '';
    this.creditCardIDNavigation = undefined;
    this.currencyRateID = 0;
    this.currencyRateIDEntity = '';
    this.currencyRateIDNavigation = undefined;
    this.customerID = 0;
    this.customerIDEntity = '';
    this.customerIDNavigation = undefined;
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
    this.salesPersonID = 0;
    this.salesPersonIDEntity = '';
    this.salesPersonIDNavigation = undefined;
    this.shipDate = undefined;
    this.shipMethodID = 0;
    this.shipToAddressID = 0;
    this.status = 0;
    this.subTotal = 0;
    this.taxAmt = 0;
    this.territoryID = 0;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
    this.totalDue = 0;
  }

  setProperties(
    accountNumber: string,
    billToAddressID: number,
    comment: string,
    creditCardApprovalCode: string,
    creditCardID: number,
    currencyRateID: number,
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
    salesPersonID: number,
    shipDate: any,
    shipMethodID: number,
    shipToAddressID: number,
    status: number,
    subTotal: number,
    taxAmt: number,
    territoryID: number,
    totalDue: number
  ): void {
    this.accountNumber = accountNumber;
    this.billToAddressID = billToAddressID;
    this.comment = comment;
    this.creditCardApprovalCode = creditCardApprovalCode;
    this.creditCardID = creditCardID;
    this.currencyRateID = currencyRateID;
    this.customerID = customerID;
    this.dueDate = moment(dueDate, 'YYYY-MM-DD');
    this.freight = freight;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.onlineOrderFlag = onlineOrderFlag;
    this.orderDate = moment(orderDate, 'YYYY-MM-DD');
    this.purchaseOrderNumber = purchaseOrderNumber;
    this.revisionNumber = revisionNumber;
    this.rowguid = rowguid;
    this.salesOrderID = salesOrderID;
    this.salesOrderNumber = salesOrderNumber;
    this.salesPersonID = salesPersonID;
    this.shipDate = moment(shipDate, 'YYYY-MM-DD');
    this.shipMethodID = shipMethodID;
    this.shipToAddressID = shipToAddressID;
    this.status = status;
    this.subTotal = subTotal;
    this.taxAmt = taxAmt;
    this.territoryID = territoryID;
    this.totalDue = totalDue;
  }

  toDisplay(): string {
    return String(this.rowguid);
  }
}


/*<Codenesium>
    <Hash>c1abdce0a1ea468ee345295d7f31a915</Hash>
</Codenesium>*/