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
    this.countryRegionCode = countryRegionCode;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>774510add0b890498d8860f1481ddff9</Hash>
</Codenesium>*/