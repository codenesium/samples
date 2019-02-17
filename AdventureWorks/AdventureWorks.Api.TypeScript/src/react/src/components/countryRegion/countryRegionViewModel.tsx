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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>396cad80e2a3d01996ace2115cb3ee2c</Hash>
</Codenesium>*/