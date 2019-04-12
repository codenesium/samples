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
    return String(this.NULL_STRING_PASSED_ToLowerCaseFirstLetter);
  }
}


/*<Codenesium>
    <Hash>535ed6b6cd8151aa32eee9469e5cd265</Hash>
</Codenesium>*/