import moment from 'moment';
import EventStatuViewModel from '../eventStatu/eventStatuViewModel';

export default class EventViewModel {
  actualEndDate: any;
  actualStartDate: any;
  billAmount: number;
  eventStatusId: number;
  eventStatusIdEntity: string;
  eventStatusIdNavigation?: EventStatuViewModel;
  id: number;
  scheduledEndDate: any;
  scheduledStartDate: any;
  studentNote: string;
  teacherNote: string;

  constructor() {
    this.actualEndDate = undefined;
    this.actualStartDate = undefined;
    this.billAmount = 0;
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
    billAmount: number,
    eventStatusId: number,
    id: number,
    scheduledEndDate: any,
    scheduledStartDate: any,
    studentNote: string,
    teacherNote: string
  ): void {
    this.actualEndDate = moment(actualEndDate, 'YYYY-MM-DD');
    this.actualStartDate = moment(actualStartDate, 'YYYY-MM-DD');
    this.billAmount = billAmount;
    this.eventStatusId = eventStatusId;
    this.id = id;
    this.scheduledEndDate = moment(scheduledEndDate, 'YYYY-MM-DD');
    this.scheduledStartDate = moment(scheduledStartDate, 'YYYY-MM-DD');
    this.studentNote = studentNote;
    this.teacherNote = teacherNote;
  }

  toDisplay(): string {
    return String(this.actualEndDate);
  }
}


/*<Codenesium>
    <Hash>60fa833d6f944ede436040c25f82d882</Hash>
</Codenesium>*/