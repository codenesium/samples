export default class RowVersionCheckViewModel {
  id: number;
  name: string;
  rowVersion: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.rowVersion = undefined;
  }

  setProperties(id: number, name: string, rowVersion: any): void {
    this.id = id;
    this.name = name;
    this.rowVersion = rowVersion;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>1324bc83de18ad7aba703ed9af977b61</Hash>
</Codenesium>*/