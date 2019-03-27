import moment from 'moment';
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
    this.date = moment(date, 'YYYY-MM-DD');
    this.description = description;
    this.endDate = moment(endDate, 'YYYY-MM-DD');
    this.facebook = facebook;
    this.id = id;
    this.name = name;
    this.startDate = moment(startDate, 'YYYY-MM-DD');
    this.website = website;
  }

  toDisplay(): string {
    return String(this.address1);
  }
}


/*<Codenesium>
    <Hash>104900f8c6097556da6be16d81a879d9</Hash>
</Codenesium>*/