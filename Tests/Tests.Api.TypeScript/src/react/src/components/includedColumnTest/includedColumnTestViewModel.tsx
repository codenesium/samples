import moment from 'moment';

export default class IncludedColumnTestViewModel {
  id: number;
  name: string;
  name2: string;

  constructor() {
    this.id = 0;
    this.name = '';
    this.name2 = '';
  }

  setProperties(id: number, name: string, name2: string): void {
    this.id = id;
    this.name = name;
    this.name2 = name2;
  }

  toDisplay(): string {
    return String(this.NULL_STRING_PASSED_ToLowerCaseFirstLetter);
  }
}


/*<Codenesium>
    <Hash>a5aba1fd9c00353bea80578916a35f70</Hash>
</Codenesium>*/