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
    this.cityIdNavigation = new CityViewModel();
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
    this.id = moment(id, 'YYYY-MM-DD');
    this.name = name;
    this.startDate = moment(startDate, 'YYYY-MM-DD');
    this.website = website;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>932d5d6c0303402e6ed2999a37ac8489</Hash>
</Codenesium>*/