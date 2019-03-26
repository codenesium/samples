import moment from 'moment';

export default class ScrapReasonViewModel {
  modifiedDate: any;
  name: string;
  scrapReasonID: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.scrapReasonID = 0;
  }

  setProperties(modifiedDate: any, name: string, scrapReasonID: number): void {
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.scrapReasonID = scrapReasonID;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>f40fd86befead146c9054aa027bbe164</Hash>
</Codenesium>*/