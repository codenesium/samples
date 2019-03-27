import moment from 'moment';

export default class VersionInfoViewModel {
  appliedOn: any;
  description: string;
  version: number;

  constructor() {
    this.appliedOn = undefined;
    this.description = '';
    this.version = 0;
  }

  setProperties(appliedOn: any, description: string, version: number): void {
    this.appliedOn = moment(appliedOn, 'YYYY-MM-DD');
    this.description = description;
    this.version = version;
  }

  toDisplay(): string {
    return String(this.appliedOn);
  }
}


/*<Codenesium>
    <Hash>fe123c090c50c7467876e43e7f2d37fc</Hash>
</Codenesium>*/