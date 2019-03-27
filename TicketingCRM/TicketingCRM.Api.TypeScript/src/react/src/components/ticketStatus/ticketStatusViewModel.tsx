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
    this.name = name;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>87b756fc3a2877d4b757f83dc0bac1ea</Hash>
</Codenesium>*/