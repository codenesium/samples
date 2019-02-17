export default class BusinessEntityViewModel {
  businessEntityID: number;
  modifiedDate: any;
  rowguid: any;

  constructor() {
    this.businessEntityID = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
  }

  setProperties(
    businessEntityID: number,
    modifiedDate: any,
    rowguid: any
  ): void {
    this.businessEntityID = businessEntityID;
    this.modifiedDate = modifiedDate;
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>945402dc0a22e8a8228ccd7fa497c3da</Hash>
</Codenesium>*/