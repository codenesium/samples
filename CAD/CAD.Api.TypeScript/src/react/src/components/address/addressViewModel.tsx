import moment from 'moment';

export default class AddressViewModel {
  address1: string;
  address2: string;
  city: string;
  id: number;
  state: string;
  zip: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.city = '';
    this.id = 0;
    this.state = '';
    this.zip = '';
  }

  setProperties(
    address1: string,
    address2: string,
    city: string,
    id: number,
    state: string,
    zip: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.city = city;
    this.id = id;
    this.state = state;
    this.zip = zip;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>2312427619fbd349ccd12f56c48ca0f1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/