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
    this.stateProvinceIDNavigation = undefined;
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
    this.addressID = addressID;
    this.addressLine1 = addressLine1;
    this.addressLine2 = addressLine2;
    this.city = city;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.postalCode = postalCode;
    this.rowguid = rowguid;
    this.stateProvinceID = stateProvinceID;
  }

  toDisplay(): string {
    return String(this.rowguid);
  }
}


/*<Codenesium>
    <Hash>e20a96d3c011066bfc823ffa5ca6ae3e</Hash>
</Codenesium>*/