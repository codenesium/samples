import moment from 'moment';
import EventStatusViewModel from '../eventStatus/eventStatusViewModel';

export default class EventViewModel {
  actualEndDate: any;
  actualStartDate: any;
  billAmount: number;
  eventStatusId: number;
  eventStatusIdEntity: string;
  eventStatusIdNavigation?: EventStatusViewModel;
  id: number;
  scheduledEndDate: any;
  scheduledStartDate: any;
  studentNotes: string;
  teacherNotes: string;

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
    this.studentNotes = '';
    this.teacherNotes = '';
  }

  setProperties(
    actualEndDate: any,
    actualStartDate: any,
    billAmount: number,
    eventStatusId: number,
    id: number,
    scheduledEndDate: any,
    scheduledStartDate: any,
    studentNotes: string,
    teacherNotes: string
  ): void {
    this.actualEndDate = moment(actualEndDate, 'YYYY-MM-DD');
    this.actualStartDate = moment(actualStartDate, 'YYYY-MM-DD');
    this.billAmount = billAmount;
    this.eventStatusId = eventStatusId;
    this.id = id;
    this.scheduledEndDate = moment(scheduledEndDate, 'YYYY-MM-DD');
    this.scheduledStartDate = moment(scheduledStartDate, 'YYYY-MM-DD');
    this.studentNotes = studentNotes;
    this.teacherNotes = teacherNotes;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>9bf4e9889ef4e08b069e513f76a48ec4</Hash>
</Codenesium>*/