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
    this.name = moment(name, 'YYYY-MM-DD');
    this.productCategoryID = moment(productCategoryID, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>977216ea818032810ef8ce0bc646c6e2</Hash>
</Codenesium>*/