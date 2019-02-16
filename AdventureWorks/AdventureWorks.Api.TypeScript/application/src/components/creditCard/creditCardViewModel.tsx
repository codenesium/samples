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
    this.modifiedDate = modifiedDate;
  }
}


/*<Codenesium>
    <Hash>082d2eb90ea74de380cb0ea4867fed76</Hash>
</Codenesium>*/