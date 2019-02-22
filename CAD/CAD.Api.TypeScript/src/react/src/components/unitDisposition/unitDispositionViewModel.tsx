import moment from 'moment';

export default class UnitDispositionViewModel {
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
    <Hash>dcc7d2b019f0fc61c4ce418979081133</Hash>
</Codenesium>*/