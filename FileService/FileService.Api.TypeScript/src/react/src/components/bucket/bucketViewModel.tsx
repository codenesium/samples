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
    return String();
  }
}


/*<Codenesium>
    <Hash>c72114aff1a1e68528e858875dbeea20</Hash>
</Codenesium>*/