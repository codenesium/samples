import moment from 'moment';
import EventViewModel from '../event/eventViewModel';
import TeacherViewModel from '../teacher/teacherViewModel';

export default class EventTeacherViewModel {
  eventId: number;
  eventIdEntity: string;
  eventIdNavigation?: EventViewModel;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherViewModel;

  constructor() {
    this.eventId = 0;
    this.eventIdEntity = '';
    this.eventIdNavigation = undefined;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
  }

  setProperties(eventId: number, teacherId: number): void {
    this.eventId = eventId;
    this.teacherId = teacherId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>c5f86ca1d522277ab8b3b9593da2406a</Hash>
</Codenesium>*/