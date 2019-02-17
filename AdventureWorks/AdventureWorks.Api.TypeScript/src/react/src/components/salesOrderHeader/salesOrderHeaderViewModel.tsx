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
  creditCardID: any;
  creditCardIDEntity: string;
  creditCardIDNavigation?: CreditCardViewModel;
  currencyRateID: any;
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
  salesPersonID: any;
  salesPersonIDEntity: string;
  salesPersonIDNavigation?: SalesPersonViewModel;
  shipDate: any;
  shipMethodID: number;
  shipToAddressID: number;
  status: number;
  subTotal: number;
  taxAmt: number;
  territoryID: any;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryViewModel;
  totalDue: number;

  constructor() {
    this.accountNumber = '';
    this.billToAddressID = 0;
    this.comment = '';
    this.creditCardApprovalCode = '';
    this.creditCardID = undefined;
    this.creditCardIDEntity = '';
    this.creditCardIDNavigation = undefined;
    this.currencyRateID = undefined;
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
    this.salesPersonID = undefined;
    this.salesPersonIDEntity = '';
    this.salesPersonIDNavigation = undefined;
    this.shipDate = undefined;
    this.shipMethodID = 0;
    this.shipToAddressID = 0;
    this.status = 0;
    this.subTotal = 0;
    this.taxAmt = 0;
    this.territoryID = undefined;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>2990605968246a86504429f6b9324c34</Hash>
</Codenesium>*/