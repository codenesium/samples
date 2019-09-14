import moment from 'moment';

export default class PostHistoryTypeViewModel {
  id: number;
  rwType: string;

  constructor() {
    this.id = 0;
    this.rwType = '';
  }

  setProperties(id: number, rwType: string): void {
    this.id = id;
    this.rwType = rwType;
  }

  toDisplay(): string {
    return String(this.rwType);
  }
}


/*<Codenesium>
    <Hash>a31090d360f5c7016ccdcc87255b75d5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/