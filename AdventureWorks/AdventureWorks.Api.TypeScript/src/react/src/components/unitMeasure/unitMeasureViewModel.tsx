export default class UnitMeasureViewModel {
  modifiedDate: any;
  name: string;
  unitMeasureCode: string;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.unitMeasureCode = '';
  }

  setProperties(
    modifiedDate: any,
    name: string,
    unitMeasureCode: string
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.unitMeasureCode = unitMeasureCode;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>bc308d05114ee62b43afbf551d04137c</Hash>
</Codenesium>*/