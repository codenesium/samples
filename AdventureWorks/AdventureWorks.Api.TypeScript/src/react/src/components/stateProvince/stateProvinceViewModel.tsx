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
    this.countryRegionCodeNavigation = new CountryRegionViewModel();
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
    this.countryRegionCode = moment(countryRegionCode, 'YYYY-MM-DD');
    this.isOnlyStateProvinceFlag = moment(
      isOnlyStateProvinceFlag,
      'YYYY-MM-DD'
    );
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
    this.stateProvinceCode = moment(stateProvinceCode, 'YYYY-MM-DD');
    this.stateProvinceID = moment(stateProvinceID, 'YYYY-MM-DD');
    this.territoryID = moment(territoryID, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>1cf29a0e24ccafc1426670b47c3a1467</Hash>
</Codenesium>*/