import moment from 'moment';
import CountryViewModel from '../country/countryViewModel';

export default class CountryRequirementViewModel {
  countryId: number;
  countryIdEntity: string;
  countryIdNavigation?: CountryViewModel;
  detail: string;
  id: number;

  constructor() {
    this.countryId = 0;
    this.countryIdEntity = '';
    this.countryIdNavigation = new CountryViewModel();
    this.detail = '';
    this.id = 0;
  }

  setProperties(countryId: number, detail: string, id: number): void {
    this.countryId = countryId;
    this.detail = detail;
    this.id = id;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>c2631b3d251a5e9c8968c15f57201aa0</Hash>
</Codenesium>*/