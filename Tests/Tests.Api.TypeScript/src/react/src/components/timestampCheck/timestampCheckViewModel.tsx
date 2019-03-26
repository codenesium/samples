import moment from 'moment';

export default class TimestampCheckViewModel {
  id: number;
  name: string;
  timestamp: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.timestamp = undefined;
  }

  setProperties(id: number, name: string, timestamp: any): void {
    this.id = id;
    this.name = name;
    this.timestamp = timestamp;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>a741ed760059473722b0cc79f62af5ce</Hash>
</Codenesium>*/