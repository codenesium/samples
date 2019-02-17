export default class ShipMethodViewModel {
  modifiedDate: any;
  name: string;
  rowguid: any;
  shipBase: number;
  shipMethodID: number;
  shipRate: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.shipBase = 0;
    this.shipMethodID = 0;
    this.shipRate = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    rowguid: any,
    shipBase: number,
    shipMethodID: number,
    shipRate: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.shipBase = shipBase;
    this.shipMethodID = shipMethodID;
    this.shipRate = shipRate;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>a3c717b4709e36f2f999653c61ea0c99</Hash>
</Codenesium>*/