import moment from 'moment';

export default class SaleViewModel {
  customerId: number;
  date: any;
  id: number;

  constructor() {
    this.customerId = 0;
    this.date = undefined;
    this.id = 0;
  }

  setProperties(customerId: number, date: any, id: number): void {
    this.customerId = customerId;
    this.date = date;
    this.id = id;
  }

  toDisplay(): string {
    return String(this.customerId);
  }
}


/*<Codenesium>
    <Hash>6489db73673d0b907951367fef0db0b3</Hash>
</Codenesium>*/