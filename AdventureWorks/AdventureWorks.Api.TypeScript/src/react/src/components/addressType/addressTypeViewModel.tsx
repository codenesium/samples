import moment from 'moment';

export default class AddressTypeViewModel {
  addressTypeID: number;
  modifiedDate: any;
  name: string;
  rowguid: any;

  constructor() {
    this.addressTypeID = 0;
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
  }

  setProperties(
    addressTypeID: number,
    modifiedDate: any,
    name: string,
    rowguid: any
  ): void {
    this.addressTypeID = addressTypeID;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>5022f7c6833df82200781da0d4b77370</Hash>
</Codenesium>*/