export default class SalesTerritoryViewModel {
  costLastYear: number;
  costYTD: number;
  countryRegionCode: string;
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
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.salesLastYear = salesLastYear;
    this.salesYTD = salesYTD;
    this.territoryID = territoryID;
  }
}


/*<Codenesium>
    <Hash>d3a4a0e9c8f0a6304a2378e9593257f6</Hash>
</Codenesium>*/