export default class ProductDescriptionViewModel {
  description: string;
  modifiedDate: any;
  productDescriptionID: number;
  rowguid: any;

  constructor() {
    this.description = '';
    this.modifiedDate = undefined;
    this.productDescriptionID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    description: string,
    modifiedDate: any,
    productDescriptionID: number,
    rowguid: any
  ): void {
    this.description = description;
    this.modifiedDate = modifiedDate;
    this.productDescriptionID = productDescriptionID;
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>b36034a641a822d0a283661a9d45c38b</Hash>
</Codenesium>*/