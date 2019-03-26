import moment from 'moment';

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
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.productCategoryID = productCategoryID;
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>7915e6249f5ff25050a3567d54b230dd</Hash>
</Codenesium>*/