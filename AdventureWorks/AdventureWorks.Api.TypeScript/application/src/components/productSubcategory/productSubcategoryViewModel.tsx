export default class ProductSubcategoryViewModel {
  modifiedDate: any;
  name: string;
  productCategoryID: number;
  productSubcategoryID: number;
  rowguid: any;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.productCategoryID = 0;
    this.productSubcategoryID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    productCategoryID: number,
    productSubcategoryID: number,
    rowguid: any
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productCategoryID = productCategoryID;
    this.productSubcategoryID = productSubcategoryID;
    this.rowguid = rowguid;
  }
}


/*<Codenesium>
    <Hash>6a42a71cf9113b059390c09e25de5446</Hash>
</Codenesium>*/