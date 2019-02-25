import moment from 'moment';
import CountryViewModel from '../country/countryViewModel';

export default class ProvinceViewModel {
  countryId: number;
  countryIdEntity: string;
  countryIdNavigation?: CountryViewModel;
  id: number;
  name: string;

  constructor() {
    this.countryId = 0;
    this.countryIdEntity = '';
    this.countryIdNavigation = new CountryViewModel();
    this.id = 0;
    this.name = '';
  }

  setProperties(countryId: number, id: number, name: string): void {
    this.countryId = countryId;
    this.id = id;
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>817540f6a6acc298b4be725f8a40a3bb</Hash>
</Codenesium>*/