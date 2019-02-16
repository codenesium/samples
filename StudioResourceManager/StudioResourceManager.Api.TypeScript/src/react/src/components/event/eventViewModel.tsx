import EventStatusViewModel from '../eventStatus/eventStatusViewModel';

export default class EventViewModel {
  actualEndDate: any;
  actualStartDate: any;
  billAmount: any;
  eventStatusId: number;
  eventStatusIdEntity: string;
  eventStatusIdNavigation?: EventStatusViewModel;
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
    this.eventStatusIdEntity = '';
    this.eventStatusIdNavigation = undefined;
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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>5888abe4156649b67ba0b9a675adc915</Hash>
</Codenesium>*/