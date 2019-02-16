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
    return String();
  }
}


/*<Codenesium>
    <Hash>1825f66cca306808b3f5bf969ceaf22c</Hash>
</Codenesium>*/