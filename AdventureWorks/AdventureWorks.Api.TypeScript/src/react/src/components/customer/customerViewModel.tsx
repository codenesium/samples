import moment from 'moment';
import StoreViewModel from '../store/storeViewModel';
import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel';

export default class CustomerViewModel {
  accountNumber: string;
  customerID: number;
  modifiedDate: any;
  personID: number;
  rowguid: any;
  storeID: number;
  storeIDEntity: string;
  storeIDNavigation?: StoreViewModel;
  territoryID: number;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryViewModel;

  constructor() {
    this.accountNumber = '';
    this.customerID = 0;
    this.modifiedDate = undefined;
    this.personID = 0;
    this.rowguid = undefined;
    this.storeID = 0;
    this.storeIDEntity = '';
    this.storeIDNavigation = undefined;
    this.territoryID = 0;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
  }

  setProperties(
    accountNumber: string,
    customerID: number,
    modifiedDate: any,
    personID: number,
    rowguid: any,
    storeID: number,
    territoryID: number
  ): void {
    this.accountNumber = accountNumber;
    this.customerID = customerID;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.personID = personID;
    this.rowguid = rowguid;
    this.storeID = storeID;
    this.territoryID = territoryID;
  }

  toDisplay(): string {
    return String(this.accountNumber);
  }
}


/*<Codenesium>
    <Hash>251a739f877f04c6d3d9269809f980ce</Hash>
</Codenesium>*/