import moment from 'moment';

export default class IllustrationViewModel {
  diagram: string;
  illustrationID: number;
  modifiedDate: any;

  constructor() {
    this.diagram = '';
    this.illustrationID = 0;
    this.modifiedDate = undefined;
  }

  setProperties(
    diagram: string,
    illustrationID: number,
    modifiedDate: any
  ): void {
    this.diagram = diagram;
    this.illustrationID = illustrationID;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String(this.diagram);
  }
}


/*<Codenesium>
    <Hash>245bb4f126a0448c98090dced3ce9515</Hash>
</Codenesium>*/