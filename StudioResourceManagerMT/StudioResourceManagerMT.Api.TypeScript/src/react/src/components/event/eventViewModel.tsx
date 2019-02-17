export default class EventViewModel {
  actualEndDate: any;
  actualStartDate: any;
  billAmount: any;
  eventStatusId: number;
  id: number;
  scheduledEndDate: any;
  scheduledStartDate: any;
  studentNote: string;
  teacherNote: string;

  constructor() {
    this.actualEndDate = undefined;
    this.actualStartDate = undefined;
    this.billAmount = undefined;
    this.eventStatusId = 0;
    this.id = 0;
    this.scheduledEndDate = undefined;
    this.scheduledStartDate = undefined;
    this.studentNote = '';
    this.teacherNote = '';
  }

  setProperties(
    actualEndDate: any,
    actualStartDate: any,
    billAmount: any,
    eventStatusId: number,
    id: number,
    scheduledEndDate: any,
    scheduledStartDate: any,
    studentNote: string,
    teacherNote: string
  ): void {
    this.actualEndDate = actualEndDate;
    this.actualStartDate = actualStartDate;
    this.billAmount = billAmount;
    this.eventStatusId = eventStatusId;
    this.id = id;
    this.scheduledEndDate = scheduledEndDate;
    this.scheduledStartDate = scheduledStartDate;
    this.studentNote = studentNote;
    this.teacherNote = teacherNote;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>160dbb139328dd9c043151ff372fb273</Hash>
</Codenesium>*/