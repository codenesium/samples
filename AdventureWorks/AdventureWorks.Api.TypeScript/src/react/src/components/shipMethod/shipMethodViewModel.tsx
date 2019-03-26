import moment from 'moment';

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
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.rowguid = rowguid;
    this.shipBase = shipBase;
    this.shipMethodID = shipMethodID;
    this.shipRate = shipRate;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>5ba5f27331d8c94b357c41b2142bb4cb</Hash>
</Codenesium>*/