import moment from 'moment';

export default class IncludedColumnTestViewModel {
  id: number;
  name: string;
  name2: string;

  constructor() {
    this.id = 0;
    this.name = '';
    this.name2 = '';
  }

  setProperties(id: number, name: string, name2: string): void {
    this.id = id;
    this.name = name;
    this.name2 = name2;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>8fdfb6d476ec697e449319ff2d910dc1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/