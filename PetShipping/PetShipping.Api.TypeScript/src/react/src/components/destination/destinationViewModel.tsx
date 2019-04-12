import moment from 'moment';
import CountryViewModel from '../country/countryViewModel';

export default class DestinationViewModel {
  countryId: number;
  countryIdEntity: string;
  countryIdNavigation?: CountryViewModel;
  id: number;
  name: string;
  order: number;

  constructor() {
    this.countryId = 0;
    this.countryIdEntity = '';
    this.countryIdNavigation = undefined;
    this.id = 0;
    this.name = '';
    this.order = 0;
  }

  setProperties(
    countryId: number,
    id: number,
    name: string,
    order: number
  ): void {
    this.countryId = countryId;
    this.id = id;
    this.name = name;
    this.order = order;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>0522a5eb41e96de5edc08757cce63217</Hash>
</Codenesium>*/