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
}


/*<Codenesium>
    <Hash>41d9e20059dab71e1499b6c13f58572c</Hash>
</Codenesium>*/