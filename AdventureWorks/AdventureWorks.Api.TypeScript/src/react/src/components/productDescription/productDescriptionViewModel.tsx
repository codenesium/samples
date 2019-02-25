import moment from 'moment';

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
    this.description = moment(description, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.productDescriptionID = moment(productDescriptionID, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>7ff934e1aa9d9d7036ee54a6ac191991</Hash>
</Codenesium>*/