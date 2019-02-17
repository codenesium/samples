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
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.reasonType = reasonType;
    this.salesReasonID = salesReasonID;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>a1a03d7be759af319cf95f582f4f6851</Hash>
</Codenesium>*/