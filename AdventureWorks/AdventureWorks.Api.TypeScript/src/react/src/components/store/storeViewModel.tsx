import moment from 'moment';
import SalesPersonViewModel from '../salesPerson/salesPersonViewModel';

export default class StoreViewModel {
  businessEntityID: number;
  demographic: string;
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesPersonID: number;
  salesPersonIDEntity: string;
  salesPersonIDNavigation?: SalesPersonViewModel;

  constructor() {
    this.businessEntityID = 0;
    this.demographic = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesPersonID = 0;
    this.salesPersonIDEntity = '';
    this.salesPersonIDNavigation = undefined;
  }

  setProperties(
    businessEntityID: number,
    demographic: string,
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesPersonID: number
  ): void {
    this.businessEntityID = businessEntityID;
    this.demographic = demographic;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.rowguid = rowguid;
    this.salesPersonID = salesPersonID;
  }

  toDisplay(): string {
    return String(this.rowguid);
  }
}


/*<Codenesium>
    <Hash>d93fcbd7ef9cc484bbd18db8bfcafab6</Hash>
</Codenesium>*/