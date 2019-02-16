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
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}


/*<Codenesium>
    <Hash>e0e9fddde189f9d516c2512bd4067fb0</Hash>
</Codenesium>*/