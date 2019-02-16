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
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.shiftID = shiftID;
    this.startTime = startTime;
  }
}


/*<Codenesium>
    <Hash>fde60fa4dc1e9297dcb129b1867ff20c</Hash>
</Codenesium>*/