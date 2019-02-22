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
    return String(this.address1);
  }
}


/*<Codenesium>
    <Hash>336509f84f4354b09c7fb48eb907cd42</Hash>
</Codenesium>*/