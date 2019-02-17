import CityViewModel from '../city/cityViewModel';

export default class EventViewModel {
  address1: string;
  address2: string;
  cityId: number;
  cityIdEntity: string;
  cityIdNavigation?: CityViewModel;
  date: any;
  description: string;
  endDate: any;
  facebook: string;
  id: number;
  name: string;
  startDate: any;
  website: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.cityId = 0;
    this.cityIdEntity = '';
    this.cityIdNavigation = undefined;
    this.date = undefined;
    this.description = '';
    this.endDate = undefined;
    this.facebook = '';
    this.id = 0;
    this.name = '';
    this.startDate = undefined;
    this.website = '';
  }

  setProperties(
    address1: string,
    address2: string,
    cityId: number,
    date: any,
    description: string,
    endDate: any,
    facebook: string,
    id: number,
    name: string,
    startDate: any,
    website: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.cityId = cityId;
    this.date = date;
    this.description = description;
    this.endDate = endDate;
    this.facebook = facebook;
    this.id = id;
    this.name = name;
    this.startDate = startDate;
    this.website = website;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>f600c838b2809d72846d7028f6480412</Hash>
</Codenesium>*/