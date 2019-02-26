import moment from 'moment';

export default class BadgeViewModel {
  date: any;
  id: number;
  name: string;
  userId: number;

  constructor() {
    this.date = undefined;
    this.id = 0;
    this.name = '';
    this.userId = 0;
  }

  setProperties(date: any, id: number, name: string, userId: number): void {
    this.date = date;
    this.id = id;
    this.name = name;
    this.userId = userId;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>4a85d6c1c285f8d62c1c90863479e353</Hash>
</Codenesium>*/