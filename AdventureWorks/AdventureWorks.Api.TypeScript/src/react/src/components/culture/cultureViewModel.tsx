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
    this.cultureID = moment(cultureID, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>36523b8b27b064f1b6146102b4f579bc</Hash>
</Codenesium>*/