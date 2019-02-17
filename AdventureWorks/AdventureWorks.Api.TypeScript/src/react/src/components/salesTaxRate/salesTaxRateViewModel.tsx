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
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.salesTaxRateID = salesTaxRateID;
    this.stateProvinceID = stateProvinceID;
    this.taxRate = taxRate;
    this.taxType = taxType;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>811c0f9334c682fe607856578e225f0d</Hash>
</Codenesium>*/