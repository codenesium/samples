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
    this.description = description;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.productDescriptionID = productDescriptionID;
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String(this.rowguid);
  }
}


/*<Codenesium>
    <Hash>ede1800233c7f475887fd9a29750b49f</Hash>
</Codenesium>*/