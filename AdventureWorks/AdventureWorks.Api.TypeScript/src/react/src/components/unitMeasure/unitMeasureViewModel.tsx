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
    this.name = name;
    this.unitMeasureCode = unitMeasureCode;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>b58b1e45a6a07df5a8373551d741565c</Hash>
</Codenesium>*/