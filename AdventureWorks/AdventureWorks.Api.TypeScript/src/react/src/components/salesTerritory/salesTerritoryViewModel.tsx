import moment from 'moment';

export default class SalesTerritoryViewModel {
  costLastYear: number;
  costYTD: number;
  countryRegionCode: string;
  reservedGroup: string;
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesLastYear: number;
  salesYTD: number;
  territoryID: number;

  constructor() {
    this.costLastYear = 0;
    this.costYTD = 0;
    this.countryRegionCode = '';
    this.reservedGroup = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesLastYear = 0;
    this.salesYTD = 0;
    this.territoryID = 0;
  }

  setProperties(
    costLastYear: number,
    costYTD: number,
    countryRegionCode: string,
    reservedGroup: string,
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesLastYear: number,
    salesYTD: number,
    territoryID: number
  ): void {
    this.costLastYear = costLastYear;
    this.costYTD = costYTD;
    this.countryRegionCode = countryRegionCode;
    this.reservedGroup = reservedGroup;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.rowguid = rowguid;
    this.salesLastYear = salesLastYear;
    this.salesYTD = salesYTD;
    this.territoryID = territoryID;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>dc15579ce5d433f923e0d0b0c92b5923</Hash>
</Codenesium>*/