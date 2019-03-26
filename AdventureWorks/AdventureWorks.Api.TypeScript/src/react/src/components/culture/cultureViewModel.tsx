import moment from 'moment';

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
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>404f77afa1c470876853e6acc3263979</Hash>
</Codenesium>*/