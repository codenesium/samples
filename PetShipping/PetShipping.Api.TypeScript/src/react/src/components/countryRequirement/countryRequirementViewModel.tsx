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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>3a557b1f48bb6a59d4a65f2351dfc162</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/