import moment from 'moment';

export default class AddressViewModel {
  addressID: number;
  addressLine1: string;
  addressLine2: string;
  city: string;
  modifiedDate: any;
  postalCode: string;
  rowguid: any;
  stateProvinceID: number;

  constructor() {
    this.addressID = 0;
    this.addressLine1 = '';
    this.addressLine2 = '';
    this.city = '';
    this.modifiedDate = undefined;
    this.postalCode = '';
    this.rowguid = undefined;
    this.stateProvinceID = 0;
  }

  setProperties(
    addressID: number,
    addressLine1: string,
    addressLine2: string,
    city: string,
    modifiedDate: any,
    postalCode: string,
    rowguid: any,
    stateProvinceID: number
  ): void {
    this.addressID = moment(addressID, 'YYYY-MM-DD');
    this.addressLine1 = moment(addressLine1, 'YYYY-MM-DD');
    this.addressLine2 = moment(addressLine2, 'YYYY-MM-DD');
    this.city = moment(city, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.postalCode = moment(postalCode, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
    this.stateProvinceID = moment(stateProvinceID, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>a23a1ae8da624418e2dfe2c72ec6a73d</Hash>
</Codenesium>*/