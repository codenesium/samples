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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>45751f3ba266bdf21310ccfca187036b</Hash>
</Codenesium>*/