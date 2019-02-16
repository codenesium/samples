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
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}


/*<Codenesium>
    <Hash>1815a428f3cc7939ca95739c1e05d110</Hash>
</Codenesium>*/