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
    this.cardNumber = cardNumber;
    this.cardType = cardType;
    this.creditCardID = creditCardID;
    this.expMonth = expMonth;
    this.expYear = expYear;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String(this.cardNumber);
  }
}


/*<Codenesium>
    <Hash>81559a6ce6c8de08d31329dcc81f4277</Hash>
</Codenesium>*/