export default class BucketViewModel {
  externalId: any;
  id: number;
  name: string;

  constructor() {
    this.externalId = undefined;
    this.id = 0;
    this.name = '';
  }

  setProperties(externalId: any, id: number, name: string): void {
    this.externalId = externalId;
    this.id = id;
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>192382de5a3395c9cf5261b7741af072</Hash>
</Codenesium>*/