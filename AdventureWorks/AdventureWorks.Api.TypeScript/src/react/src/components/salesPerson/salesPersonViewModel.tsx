import moment from 'moment';
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
    this.territoryIDNavigation = new SalesTerritoryViewModel();
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
    this.bonus = moment(bonus, 'YYYY-MM-DD');
    this.businessEntityID = moment(businessEntityID, 'YYYY-MM-DD');
    this.commissionPct = moment(commissionPct, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
    this.salesLastYear = moment(salesLastYear, 'YYYY-MM-DD');
    this.salesQuota = moment(salesQuota, 'YYYY-MM-DD');
    this.salesYTD = moment(salesYTD, 'YYYY-MM-DD');
    this.territoryID = moment(territoryID, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>291ff9ac4392d5d9e373c5553b4dfe90</Hash>
</Codenesium>*/