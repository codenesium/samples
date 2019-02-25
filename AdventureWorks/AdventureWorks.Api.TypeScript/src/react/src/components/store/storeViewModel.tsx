import moment from 'moment';
import SalesPersonViewModel from '../salesPerson/salesPersonViewModel';

export default class StoreViewModel {
  businessEntityID: number;
  demographic: string;
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesPersonID: any;
  salesPersonIDEntity: string;
  salesPersonIDNavigation?: SalesPersonViewModel;

  constructor() {
    this.businessEntityID = 0;
    this.demographic = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesPersonID = undefined;
    this.salesPersonIDEntity = '';
    this.salesPersonIDNavigation = new SalesPersonViewModel();
  }

  setProperties(
    businessEntityID: number,
    demographic: string,
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesPersonID: any
  ): void {
    this.businessEntityID = moment(businessEntityID, 'YYYY-MM-DD');
    this.demographic = moment(demographic, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
    this.salesPersonID = moment(salesPersonID, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>1e33f2945003855d19894dbe18635b06</Hash>
</Codenesium>*/