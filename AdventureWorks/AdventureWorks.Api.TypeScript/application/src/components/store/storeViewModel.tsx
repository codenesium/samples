export default class StoreViewModel {
  businessEntityID: number;
  demographic: string;
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesPersonID: any;
  salesPersonIDEntity: string;

  constructor() {
    this.businessEntityID = 0;
    this.demographic = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesPersonID = undefined;
    this.salesPersonIDEntity = '';
  }

  setProperties(
    businessEntityID: number,
    demographic: string,
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesPersonID: any
  ): void {
    this.businessEntityID = businessEntityID;
    this.demographic = demographic;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.salesPersonID = salesPersonID;
  }
}


/*<Codenesium>
    <Hash>6fdd977477fb2448457f69d150fa1ebf</Hash>
</Codenesium>*/