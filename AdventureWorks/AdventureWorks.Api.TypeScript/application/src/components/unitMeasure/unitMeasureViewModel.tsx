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
}


/*<Codenesium>
    <Hash>bd5af0615891df52b9f1e29f9a8fe502</Hash>
</Codenesium>*/