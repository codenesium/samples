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
}


/*<Codenesium>
    <Hash>197d2178d7bd9b2f00277ad43c98c62e</Hash>
</Codenesium>*/