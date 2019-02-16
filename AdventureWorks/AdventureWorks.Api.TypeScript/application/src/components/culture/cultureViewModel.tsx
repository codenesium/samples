export default class CultureViewModel {
  cultureID: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.cultureID = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(cultureID: string, modifiedDate: any, name: string): void {
    this.cultureID = cultureID;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}


/*<Codenesium>
    <Hash>01b45832791f34e9d1da0e4037a55901</Hash>
</Codenesium>*/