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
    this.countryIdNavigation = new CountryViewModel();
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
    this.countryId = moment(countryId, 'YYYY-MM-DD');
    this.id = moment(id, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.order = moment(order, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>f0a6dd4c615f782b48bc3a06a848edf8</Hash>
</Codenesium>*/