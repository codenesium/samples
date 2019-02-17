export default class StateProvinceViewModel {
  countryRegionCode: string;
  isOnlyStateProvinceFlag: boolean;
  modifiedDate: any;
  name: string;
  rowguid: any;
  stateProvinceCode: string;
  stateProvinceID: number;
  territoryID: number;

  constructor() {
    this.countryRegionCode = '';
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
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.stateProvinceCode = stateProvinceCode;
    this.stateProvinceID = stateProvinceID;
    this.territoryID = territoryID;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>89637a5ff5a77b5d10b4cc16ffdd3ca9</Hash>
</Codenesium>*/