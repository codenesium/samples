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
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>ab70a118b7020546a2b33f92339ebe31</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/