import moment from 'moment';

export default class SalesReasonViewModel {
  modifiedDate: any;
  name: string;
  reasonType: string;
  salesReasonID: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.reasonType = '';
    this.salesReasonID = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    reasonType: string,
    salesReasonID: number
  ): void {
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.reasonType = reasonType;
    this.salesReasonID = salesReasonID;
  }

  toDisplay(): string {
    return String(this.modifiedDate);
  }
}


/*<Codenesium>
    <Hash>f0299d79fb9acb66d4cf94ed5b7c9fd3</Hash>
</Codenesium>*/