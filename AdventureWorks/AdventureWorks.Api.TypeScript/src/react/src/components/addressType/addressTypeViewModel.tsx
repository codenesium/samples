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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>a087b44a4820457923f84e01cd6c85bd</Hash>
</Codenesium>*/