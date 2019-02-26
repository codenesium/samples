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
    this.name = moment(name, 'YYYY-MM-DD');
    this.scrapReasonID = moment(scrapReasonID, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>8c77aed56c215c536ff6b8a29c279991</Hash>
</Codenesium>*/