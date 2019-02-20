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
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>4a6e1c12fd31d56c50e623ce18a2bcad</Hash>
</Codenesium>*/