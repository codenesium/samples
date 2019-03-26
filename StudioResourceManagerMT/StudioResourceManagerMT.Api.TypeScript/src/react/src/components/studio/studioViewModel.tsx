import moment from 'moment';

export default class StudioViewModel {
  address1: string;
  address2: string;
  city: string;
  id: number;
  name: string;
  province: string;
  website: string;
  zip: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.city = '';
    this.id = 0;
    this.name = '';
    this.province = '';
    this.website = '';
    this.zip = '';
  }

  setProperties(
    address1: string,
    address2: string,
    city: string,
    id: number,
    name: string,
    province: string,
    website: string,
    zip: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.city = city;
    this.id = id;
    this.name = name;
    this.province = province;
    this.website = website;
    this.zip = zip;
  }

  toDisplay(): string {
    return String(this.address1);
  }
}


/*<Codenesium>
    <Hash>056dbd15f272ac433f89c6e51b3d7e12</Hash>
</Codenesium>*/