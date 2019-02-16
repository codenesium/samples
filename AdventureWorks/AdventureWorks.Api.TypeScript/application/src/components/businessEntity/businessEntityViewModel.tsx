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
}


/*<Codenesium>
    <Hash>2d42729b723992297c0c2ce04c5977f9</Hash>
</Codenesium>*/