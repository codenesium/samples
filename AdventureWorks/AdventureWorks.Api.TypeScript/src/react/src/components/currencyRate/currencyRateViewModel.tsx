import moment from 'moment';
import CurrencyViewModel from '../currency/currencyViewModel';

export default class CurrencyRateViewModel {
  averageRate: number;
  currencyRateDate: any;
  currencyRateID: number;
  endOfDayRate: number;
  fromCurrencyCode: string;
  fromCurrencyCodeEntity: string;
  fromCurrencyCodeNavigation?: CurrencyViewModel;
  modifiedDate: any;
  toCurrencyCode: string;
  toCurrencyCodeEntity: string;
  toCurrencyCodeNavigation?: CurrencyViewModel;

  constructor() {
    this.averageRate = 0;
    this.currencyRateDate = undefined;
    this.currencyRateID = 0;
    this.endOfDayRate = 0;
    this.fromCurrencyCode = '';
    this.fromCurrencyCodeEntity = '';
    this.fromCurrencyCodeNavigation = undefined;
    this.modifiedDate = undefined;
    this.toCurrencyCode = '';
    this.toCurrencyCodeEntity = '';
    this.toCurrencyCodeNavigation = undefined;
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
    this.currencyRateDate = moment(currencyRateDate, 'YYYY-MM-DD');
    this.currencyRateID = currencyRateID;
    this.endOfDayRate = endOfDayRate;
    this.fromCurrencyCode = fromCurrencyCode;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.toCurrencyCode = toCurrencyCode;
  }

  toDisplay(): string {
    return String(this.currencyRateDate);
  }
}


/*<Codenesium>
    <Hash>4748e9480718c9f36a55c27b46ff2830</Hash>
</Codenesium>*/