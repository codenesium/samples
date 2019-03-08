import moment from 'moment';

export default class PaymentTypeViewModel {
  name: string;

  constructor() {
    this.name = '';
  }

  setProperties(name: string): void {
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>4a0539cbc86d1a01def2bee1952c0216</Hash>
</Codenesium>*/