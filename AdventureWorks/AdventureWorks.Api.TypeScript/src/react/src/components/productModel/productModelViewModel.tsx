export default class ProductModelViewModel {
  catalogDescription: string;
  instruction: string;
  modifiedDate: any;
  name: string;
  productModelID: number;
  rowguid: any;

  constructor() {
    this.catalogDescription = '';
    this.instruction = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.productModelID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    catalogDescription: string,
    instruction: string,
    modifiedDate: any,
    name: string,
    productModelID: number,
    rowguid: any
  ): void {
    this.catalogDescription = catalogDescription;
    this.instruction = instruction;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productModelID = productModelID;
    this.rowguid = rowguid;
  }
}


/*<Codenesium>
    <Hash>60e7b1c7f2f1ff20147a46a1d8dfddd3</Hash>
</Codenesium>*/