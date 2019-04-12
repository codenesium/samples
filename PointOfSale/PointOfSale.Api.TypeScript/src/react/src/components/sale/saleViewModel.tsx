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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>d80280f13a45f26dab742792b524756f</Hash>
</Codenesium>*/