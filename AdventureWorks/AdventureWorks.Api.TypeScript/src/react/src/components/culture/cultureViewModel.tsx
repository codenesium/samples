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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>9f29af8c8b57beaa084414db03fb0cad</Hash>
</Codenesium>*/