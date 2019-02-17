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
    <Hash>8c1d33a02bbd3af4e8cb3f2817629e9b</Hash>
</Codenesium>*/