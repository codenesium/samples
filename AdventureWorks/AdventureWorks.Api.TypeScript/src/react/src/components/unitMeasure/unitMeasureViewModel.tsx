import moment from 'moment';

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
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.unitMeasureCode = moment(unitMeasureCode, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>754d2d8f912b420f87bfc6af7bf02d0c</Hash>
</Codenesium>*/