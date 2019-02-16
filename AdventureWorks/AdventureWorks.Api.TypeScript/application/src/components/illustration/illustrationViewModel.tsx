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
    this.modifiedDate = modifiedDate;
  }
}


/*<Codenesium>
    <Hash>1856702d2b25b2e3447d3c756b5df0fe</Hash>
</Codenesium>*/