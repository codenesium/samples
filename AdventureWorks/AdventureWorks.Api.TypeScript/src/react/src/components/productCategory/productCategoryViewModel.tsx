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
}


/*<Codenesium>
    <Hash>4366083b347acfffb1a28a2fa0e1017b</Hash>
</Codenesium>*/