import moment from 'moment';

export default class UnitViewModel {
  callSign: string;
  id: number;

  constructor() {
    this.callSign = '';
    this.id = 0;
  }

  setProperties(callSign: string, id: number): void {
    this.callSign = callSign;
    this.id = id;
  }

  toDisplay(): string {
    return String(this.callSign);
  }
}


/*<Codenesium>
    <Hash>5067c2abf68bb8ba07e4628e27cdc68a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/