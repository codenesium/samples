import moment from 'moment';

export default class ChainStatusViewModel {
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
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>5adee926b1b4d2fe7f092ecb3ed9df03</Hash>
</Codenesium>*/