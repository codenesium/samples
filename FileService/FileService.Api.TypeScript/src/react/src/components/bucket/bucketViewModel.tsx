import moment from 'moment';

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
    <Hash>5f236311002bf9414f21e02d6050424e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/