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
    this.fromCurrencyCodeNavigation = new CurrencyViewModel();
    this.modifiedDate = undefined;
    this.toCurrencyCode = '';
    this.toCurrencyCodeEntity = '';
    this.toCurrencyCodeNavigation = new CurrencyViewModel();
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
    this.averageRate = moment(averageRate, 'YYYY-MM-DD');
    this.currencyRateDate = moment(currencyRateDate, 'YYYY-MM-DD');
    this.currencyRateID = moment(currencyRateID, 'YYYY-MM-DD');
    this.endOfDayRate = moment(endOfDayRate, 'YYYY-MM-DD');
    this.fromCurrencyCode = moment(fromCurrencyCode, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.toCurrencyCode = moment(toCurrencyCode, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>980977390d6329f37877e2f08f4d77a2</Hash>
</Codenesium>*/