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
    return String();
  }
}


/*<Codenesium>
    <Hash>8bf508d5c3a2b46001342d332d180717</Hash>
</Codenesium>*/