import moment from 'moment';
import EventViewModel from '../event/eventViewModel';
import StudentViewModel from '../student/studentViewModel';

export default class EventStudentViewModel {
  eventId: number;
  eventIdEntity: string;
  eventIdNavigation?: EventViewModel;
  studentId: number;
  studentIdEntity: string;
  studentIdNavigation?: StudentViewModel;

  constructor() {
    this.eventId = 0;
    this.eventIdEntity = '';
    this.eventIdNavigation = undefined;
    this.studentId = 0;
    this.studentIdEntity = '';
    this.studentIdNavigation = undefined;
  }

  setProperties(eventId: number, studentId: number): void {
    this.eventId = eventId;
    this.studentId = studentId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>4b9d9992a3038858150a9b01af66a94d</Hash>
</Codenesium>*/