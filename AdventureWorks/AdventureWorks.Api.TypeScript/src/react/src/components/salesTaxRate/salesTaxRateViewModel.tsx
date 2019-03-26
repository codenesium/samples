import moment from 'moment';

export default class SalesTaxRateViewModel {
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesTaxRateID: number;
  stateProvinceID: number;
  taxRate: number;
  taxType: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesTaxRateID = 0;
    this.stateProvinceID = 0;
    this.taxRate = 0;
    this.taxType = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesTaxRateID: number,
    stateProvinceID: number,
    taxRate: number,
    taxType: number
  ): void {
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.rowguid = rowguid;
    this.salesTaxRateID = salesTaxRateID;
    this.stateProvinceID = stateProvinceID;
    this.taxRate = taxRate;
    this.taxType = taxType;
  }

  toDisplay(): string {
    return String(this.rowguid);
  }
}


/*<Codenesium>
    <Hash>9e77766700e5196444e4882d50135049</Hash>
</Codenesium>*/