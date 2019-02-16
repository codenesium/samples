export default class AddressTypeViewModel {
  addressTypeID: number;
  modifiedDate: any;
  name: string;
  rowguid: any;

  constructor() {
    this.addressTypeID = 0;
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
  }

  setProperties(
    addressTypeID: number,
    modifiedDate: any,
    name: string,
    rowguid: any
  ): void {
    this.addressTypeID = addressTypeID;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
  }
}


/*<Codenesium>
    <Hash>8d1489ddb5758b988dadda25430c2fff</Hash>
</Codenesium>*/