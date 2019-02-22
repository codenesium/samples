import moment from 'moment';

export default class VehicleViewModel {
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
    <Hash>dddfd85d303cedbe4e14d7dd36aa2349</Hash>
</Codenesium>*/