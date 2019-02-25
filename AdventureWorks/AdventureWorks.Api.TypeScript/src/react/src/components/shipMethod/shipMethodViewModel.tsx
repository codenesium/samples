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
    this.name = moment(name, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
    this.shipBase = moment(shipBase, 'YYYY-MM-DD');
    this.shipMethodID = moment(shipMethodID, 'YYYY-MM-DD');
    this.shipRate = moment(shipRate, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>ae6a41616804a9d96e7ca0c17c39e73b</Hash>
</Codenesium>*/