import moment from 'moment';

export default class PipelineStatusViewModel {
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
    <Hash>257bbcd97e68ad34089b1b487ab51abf</Hash>
</Codenesium>*/