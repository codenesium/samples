import moment from 'moment';

export default class TicketStatusViewModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = moment(name, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>bb1cccd9e71aa305a3bb3c5414c92313</Hash>
</Codenesium>*/