import moment from 'moment';

export default class CountryRegionViewModel {
  countryRegionCode: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.countryRegionCode = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(
    countryRegionCode: string,
    modifiedDate: any,
    name: string
  ): void {
    this.countryRegionCode = moment(countryRegionCode, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>8ecb4ad617650c6d9f7bb4f52becbeaf</Hash>
</Codenesium>*/