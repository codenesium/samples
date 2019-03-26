import moment from 'moment';

export default class BusinessEntityViewModel {
  businessEntityID: number;
  modifiedDate: any;
  rowguid: any;

  constructor() {
    this.businessEntityID = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
  }

  setProperties(
    businessEntityID: number,
    modifiedDate: any,
    rowguid: any
  ): void {
    this.businessEntityID = businessEntityID;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String(this.rowguid);
  }
}


/*<Codenesium>
    <Hash>b92b1e0e42ef2b283ccd18f793af8eaf</Hash>
</Codenesium>*/