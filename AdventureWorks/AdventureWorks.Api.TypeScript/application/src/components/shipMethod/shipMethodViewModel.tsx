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
}


/*<Codenesium>
    <Hash>65a95768cb61b8519fda480f7339f39f</Hash>
</Codenesium>*/