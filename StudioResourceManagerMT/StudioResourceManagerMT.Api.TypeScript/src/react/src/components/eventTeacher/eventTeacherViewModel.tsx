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
    return String();
  }
}


/*<Codenesium>
    <Hash>e8d11a61b99e2d71adff9ad73d393445</Hash>
</Codenesium>*/