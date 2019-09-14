import moment from 'moment';

export default class SpaceFeatureViewModel {
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
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>0dda4a5dda629177ed8d2a9fab33429e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/