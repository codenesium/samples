import moment from 'moment';

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
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>5e24486934f3ba1b369675ac1d2d0f63</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/