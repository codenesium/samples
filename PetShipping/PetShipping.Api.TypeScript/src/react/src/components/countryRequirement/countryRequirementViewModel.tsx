import moment from 'moment';
import CountryViewModel from '../country/countryViewModel';

export default class CountryRequirementViewModel {
  countryId: number;
  countryIdEntity: string;
  countryIdNavigation?: CountryViewModel;
  details: string;
  id: number;

  constructor() {
    this.countryId = 0;
    this.countryIdEntity = '';
    this.countryIdNavigation = undefined;
    this.details = '';
    this.id = 0;
  }

  setProperties(countryId: number, details: string, id: number): void {
    this.countryId = countryId;
    this.details = details;
    this.id = id;
  }

  toDisplay(): string {
    return String(this.countryId);
  }
}


/*<Codenesium>
    <Hash>927ba7a97821879aa94057a846b87758</Hash>
</Codenesium>*/