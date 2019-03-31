import moment from 'moment';
import EventViewModel from '../event/eventViewModel';
import TeacherViewModel from '../teacher/teacherViewModel';

export default class EventTeacherViewModel {
  eventId: number;
  eventIdEntity: string;
  eventIdNavigation?: EventViewModel;
  id: number;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherViewModel;

  constructor() {
    this.eventId = 0;
    this.eventIdEntity = '';
    this.eventIdNavigation = undefined;
    this.id = 0;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
  }

  setProperties(eventId: number, id: number, teacherId: number): void {
    this.eventId = eventId;
    this.id = id;
    this.teacherId = teacherId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>4904c9269921a946c6cf456d5c5fb0c6</Hash>
</Codenesium>*/