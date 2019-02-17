import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel';

export default class SalesPersonViewModel {
  bonus: number;
  businessEntityID: number;
  commissionPct: number;
  modifiedDate: any;
  rowguid: any;
  salesLastYear: number;
  salesQuota: any;
  salesYTD: number;
  territoryID: any;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryViewModel;

  constructor() {
    this.bonus = 0;
    this.businessEntityID = 0;
    this.commissionPct = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
    this.salesLastYear = 0;
    this.salesQuota = undefined;
    this.salesYTD = 0;
    this.territoryID = undefined;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
  }

  setProperties(
    bonus: number,
    businessEntityID: number,
    commissionPct: number,
    modifiedDate: any,
    rowguid: any,
    salesLastYear: number,
    salesQuota: any,
    salesYTD: number,
    territoryID: any
  ): void {
    this.bonus = bonus;
    this.businessEntityID = businessEntityID;
    this.commissionPct = commissionPct;
    this.modifiedDate = modifiedDate;
    this.rowguid = rowguid;
    this.salesLastYear = salesLastYear;
    this.salesQuota = salesQuota;
    this.salesYTD = salesYTD;
    this.territoryID = territoryID;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>40bece27f6bae1ec71a7c35b3d15478b</Hash>
</Codenesium>*/