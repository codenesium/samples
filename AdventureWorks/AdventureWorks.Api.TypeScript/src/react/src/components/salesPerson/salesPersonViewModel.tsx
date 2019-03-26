import moment from 'moment';
import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel';

export default class SalesPersonViewModel {
  bonus: number;
  businessEntityID: number;
  commissionPct: number;
  modifiedDate: any;
  rowguid: any;
  salesLastYear: number;
  salesQuota: number;
  salesYTD: number;
  territoryID: number;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryViewModel;

  constructor() {
    this.bonus = 0;
    this.businessEntityID = 0;
    this.commissionPct = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
    this.salesLastYear = 0;
    this.salesQuota = 0;
    this.salesYTD = 0;
    this.territoryID = 0;
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
    salesQuota: number,
    salesYTD: number,
    territoryID: number
  ): void {
    this.bonus = bonus;
    this.businessEntityID = businessEntityID;
    this.commissionPct = commissionPct;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.rowguid = rowguid;
    this.salesLastYear = salesLastYear;
    this.salesQuota = salesQuota;
    this.salesYTD = salesYTD;
    this.territoryID = territoryID;
  }

  toDisplay(): string {
    return String(this.rowguid);
  }
}


/*<Codenesium>
    <Hash>e468485f462ed87f902103ab2d42a0a9</Hash>
</Codenesium>*/