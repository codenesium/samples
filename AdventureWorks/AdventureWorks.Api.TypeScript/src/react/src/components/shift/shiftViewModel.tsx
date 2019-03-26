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
    this.endTime = endTime;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.shiftID = shiftID;
    this.startTime = startTime;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>2a5d9702a74fe0c6383813aca1c5b6cb</Hash>
</Codenesium>*/