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
    this.countryIdNavigation = undefined;
    this.id = 0;
    this.name = '';
  }

  setProperties(countryId: number, id: number, name: string): void {
    this.countryId = countryId;
    this.id = id;
    this.name = name;
  }

  toDisplay(): string {
    return String(this.countryId);
  }
}


/*<Codenesium>
    <Hash>be9cc8957b89625567fb13f35697679b</Hash>
</Codenesium>*/