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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>a78e7b923bbc4cc610b04096f6bfeb1c</Hash>
</Codenesium>*/