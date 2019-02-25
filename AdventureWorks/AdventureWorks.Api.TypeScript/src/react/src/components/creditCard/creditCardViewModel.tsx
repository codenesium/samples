import moment from 'moment';

export default class CreditCardViewModel {
  cardNumber: string;
  cardType: string;
  creditCardID: number;
  expMonth: number;
  expYear: number;
  modifiedDate: any;

  constructor() {
    this.cardNumber = '';
    this.cardType = '';
    this.creditCardID = 0;
    this.expMonth = 0;
    this.expYear = 0;
    this.modifiedDate = undefined;
  }

  setProperties(
    cardNumber: string,
    cardType: string,
    creditCardID: number,
    expMonth: number,
    expYear: number,
    modifiedDate: any
  ): void {
    this.cardNumber = moment(cardNumber, 'YYYY-MM-DD');
    this.cardType = moment(cardType, 'YYYY-MM-DD');
    this.creditCardID = moment(creditCardID, 'YYYY-MM-DD');
    this.expMonth = moment(expMonth, 'YYYY-MM-DD');
    this.expYear = moment(expYear, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>07f20ef5b6a7acf0e686fd8747cff753</Hash>
</Codenesium>*/