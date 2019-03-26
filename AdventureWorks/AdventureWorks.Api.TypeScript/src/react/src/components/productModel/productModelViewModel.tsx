import moment from 'moment';

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
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.productModelID = productModelID;
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>e00a6d289a7b06b9e2038328efb83227</Hash>
</Codenesium>*/