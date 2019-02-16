export default class CustomerViewModel {
  accountNumber: string;
  customerID: number;
  modifiedDate: any;
  personID: any;
  rowguid: any;
  storeID: any;
  storeIDEntity: string;
  territoryID: any;
  territoryIDEntity: string;

  constructor() {
    this.accountNumber = '';
    this.customerID = 0;
    this.modifiedDate = undefined;
    this.personID = undefined;
    this.rowguid = undefined;
    this.storeID = undefined;
    this.storeIDEntity = '';
    this.territoryID = undefined;
    this.territoryIDEntity = '';
  }

  setProperties(
    accountNumber: string,
    customerID: number,
    modifiedDate: any,
    personID: any,
    rowguid: any,
    storeID: any,
    territoryID: any
  ): void {
    this.accountNumber = accountNumber;
    this.customerID = customerID;
    this.modifiedDate = modifiedDate;
    this.personID = personID;
    this.rowguid = rowguid;
    this.storeID = storeID;
    this.territoryID = territoryID;
  }
}


/*<Codenesium>
    <Hash>c2571399994fb41aafab4278534b367c</Hash>
</Codenesium>*/