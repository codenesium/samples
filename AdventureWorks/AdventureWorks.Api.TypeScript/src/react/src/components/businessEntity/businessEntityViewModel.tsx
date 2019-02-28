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
    this.businessEntityID = moment(businessEntityID, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>08aa55209e395fc948f0c74b910c5545</Hash>
</Codenesium>*/