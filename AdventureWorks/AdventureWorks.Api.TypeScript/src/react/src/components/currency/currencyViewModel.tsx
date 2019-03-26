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
    this.currencyCode = currencyCode;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>43c602e1e75fbc9fe860e4d9830804f8</Hash>
</Codenesium>*/