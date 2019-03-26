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
    return String();
  }
}


/*<Codenesium>
    <Hash>e6152f6558810b259caf2bcad00919f1</Hash>
</Codenesium>*/