import moment from 'moment';

export default class CurrencyViewModel {
  currencyCode: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.currencyCode = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(currencyCode: string, modifiedDate: any, name: string): void {
    this.currencyCode = moment(currencyCode, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>a0a3fb4ef06f51c209955ccbed550130</Hash>
</Codenesium>*/