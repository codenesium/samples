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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>899312ebb9ad0052d7cc233841a8e96f</Hash>
</Codenesium>*/