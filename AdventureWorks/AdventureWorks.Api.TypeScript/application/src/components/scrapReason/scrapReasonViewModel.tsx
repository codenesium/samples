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
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.scrapReasonID = scrapReasonID;
  }
}


/*<Codenesium>
    <Hash>61a8125d9bf45add25d0563c14919f41</Hash>
</Codenesium>*/