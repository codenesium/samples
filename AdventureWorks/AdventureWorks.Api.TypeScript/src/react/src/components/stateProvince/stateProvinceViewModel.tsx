import moment from 'moment';
import CountryRegionViewModel from '../countryRegion/countryRegionViewModel';

export default class StateProvinceViewModel {
  countryRegionCode: string;
  countryRegionCodeEntity: string;
  countryRegionCodeNavigation?: CountryRegionViewModel;
  isOnlyStateProvinceFlag: boolean;
  modifiedDate: any;
  name: string;
  rowguid: any;
  stateProvinceCode: string;
  stateProvinceID: number;
  territoryID: number;

  constructor() {
    this.countryRegionCode = '';
    this.countryRegionCodeEntity = '';
    this.countryRegionCodeNavigation = undefined;
    this.isOnlyStateProvinceFlag = false;
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.stateProvinceCode = '';
    this.stateProvinceID = 0;
    this.territoryID = 0;
  }

  setProperties(
    countryRegionCode: string,
    isOnlyStateProvinceFlag: boolean,
    modifiedDate: any,
    name: string,
    rowguid: any,
    stateProvinceCode: string,
    stateProvinceID: number,
    territoryID: number
  ): void {
    this.countryRegionCode = countryRegionCode;
    this.isOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.rowguid = rowguid;
    this.stateProvinceCode = stateProvinceCode;
    this.stateProvinceID = stateProvinceID;
    this.territoryID = territoryID;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>70f0c8c1391826d1727eaaedd3cd7e06</Hash>
</Codenesium>*/