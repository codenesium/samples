import moment from 'moment';

export default class ShiftViewModel {
  endTime: any;
  modifiedDate: any;
  name: string;
  shiftID: number;
  startTime: any;

  constructor() {
    this.endTime = undefined;
    this.modifiedDate = undefined;
    this.name = '';
    this.shiftID = 0;
    this.startTime = undefined;
  }

  setProperties(
    endTime: any,
    modifiedDate: any,
    name: string,
    shiftID: number,
    startTime: any
  ): void {
    this.endTime = moment(endTime, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.shiftID = moment(shiftID, 'YYYY-MM-DD');
    this.startTime = moment(startTime, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>888ec05a4641df629f64b41fd60301d4</Hash>
</Codenesium>*/