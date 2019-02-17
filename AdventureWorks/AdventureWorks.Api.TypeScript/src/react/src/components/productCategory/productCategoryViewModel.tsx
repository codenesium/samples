export default class ProductCategoryViewModel {
  modifiedDate: any;
  name: string;
  productCategoryID: number;
  rowguid: any;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.productCategoryID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    productCategoryID: number,
    rowguid: any
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productCategoryID = productCategoryID;
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>c1256eab9a908f49985e7f4ec882a70e</Hash>
</Codenesium>*/