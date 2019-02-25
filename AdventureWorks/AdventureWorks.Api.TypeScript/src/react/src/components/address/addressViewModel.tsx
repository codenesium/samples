import moment from 'moment';
import StateProvinceViewModel from '../stateProvince/stateProvinceViewModel';

export default class AddressViewModel {
  addressID: number;
  addressLine1: string;
  addressLine2: string;
  city: string;
  modifiedDate: any;
  postalCode: string;
  rowguid: any;
  stateProvinceID: number;
  stateProvinceIDEntity: string;
  stateProvinceIDNavigation?: StateProvinceViewModel;

  constructor() {
    this.addressID = 0;
    this.addressLine1 = '';
    this.addressLine2 = '';
    this.city = '';
    this.modifiedDate = undefined;
    this.postalCode = '';
    this.rowguid = undefined;
    this.stateProvinceID = 0;
    this.stateProvinceIDEntity = '';
    this.stateProvinceIDNavigation = new StateProvinceViewModel();
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
    <Hash>abe687a915eee465ab6873d0182e383c</Hash>
</Codenesium>*/