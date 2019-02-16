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
}


/*<Codenesium>
    <Hash>2cb4a1a3ef018a492549fa0e15fca6e6</Hash>
</Codenesium>*/