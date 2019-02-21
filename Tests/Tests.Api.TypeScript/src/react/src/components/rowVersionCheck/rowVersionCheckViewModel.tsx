import moment from 'moment';

export default class RowVersionCheckViewModel {
  id: number;
  name: string;
  rowVersion: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.rowVersion = undefined;
  }

  setProperties(id: number, name: string, rowVersion: any): void {
    this.id = id;
    this.name = name;
    this.rowVersion = rowVersion;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>fe40cd1602ec76c650bfe2dc9fb17f10</Hash>
</Codenesium>*/