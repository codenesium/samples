import moment from 'moment';
import EventViewModel from '../event/eventViewModel';
import StudentViewModel from '../student/studentViewModel';

export default class EventStudentViewModel {
  eventId: number;
  eventIdEntity: string;
  eventIdNavigation?: EventViewModel;
  id: number;
  studentId: number;
  studentIdEntity: string;
  studentIdNavigation?: StudentViewModel;

  constructor() {
    this.eventId = 0;
    this.eventIdEntity = '';
    this.eventIdNavigation = undefined;
    this.id = 0;
    this.studentId = 0;
    this.studentIdEntity = '';
    this.studentIdNavigation = undefined;
  }

  setProperties(eventId: number, id: number, studentId: number): void {
    this.eventId = eventId;
    this.id = id;
    this.studentId = studentId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>58895a38398d964899c3d6286f106269</Hash>
</Codenesium>*/