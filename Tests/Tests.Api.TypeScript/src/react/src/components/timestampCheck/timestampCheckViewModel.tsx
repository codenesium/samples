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
    <Hash>27211c83a745eb1b60b737443cdc37cd</Hash>
</Codenesium>*/