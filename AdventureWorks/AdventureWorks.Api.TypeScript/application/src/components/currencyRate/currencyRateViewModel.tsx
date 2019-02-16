export default class CurrencyRateViewModel {
  averageRate: number;
  currencyRateDate: any;
  currencyRateID: number;
  endOfDayRate: number;
  fromCurrencyCode: string;
  fromCurrencyCodeEntity: string;
  modifiedDate: any;
  toCurrencyCode: string;
  toCurrencyCodeEntity: string;

  constructor() {
    this.averageRate = 0;
    this.currencyRateDate = undefined;
    this.currencyRateID = 0;
    this.endOfDayRate = 0;
    this.fromCurrencyCode = '';
    this.fromCurrencyCodeEntity = '';
    this.modifiedDate = undefined;
    this.toCurrencyCode = '';
    this.toCurrencyCodeEntity = '';
  }

  setProperties(
    averageRate: number,
    currencyRateDate: any,
    currencyRateID: number,
    endOfDayRate: number,
    fromCurrencyCode: string,
    modifiedDate: any,
    toCurrencyCode: string
  ): void {
    this.averageRate = averageRate;
    this.currencyRateDate = currencyRateDate;
    this.currencyRateID = currencyRateID;
    this.endOfDayRate = endOfDayRate;
    this.fromCurrencyCode = fromCurrencyCode;
    this.modifiedDate = modifiedDate;
    this.toCurrencyCode = toCurrencyCode;
  }
}


/*<Codenesium>
    <Hash>0b5bb4b02e72498ab79d68e5d0367e35</Hash>
</Codenesium>*/