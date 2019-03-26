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
    this.countryIdNavigation = undefined;
    this.detail = '';
    this.id = 0;
  }

  setProperties(countryId: number, detail: string, id: number): void {
    this.countryId = countryId;
    this.detail = detail;
    this.id = id;
  }

  toDisplay(): string {
    return String(this.countryId);
  }
}


/*<Codenesium>
    <Hash>10fb468041065c85fc35ab4a35f355d9</Hash>
</Codenesium>*/