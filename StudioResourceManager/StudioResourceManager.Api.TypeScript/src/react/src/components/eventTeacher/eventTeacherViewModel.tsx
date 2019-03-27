import moment from 'moment';
import EventViewModel from '../event/eventViewModel';
import TeacherViewModel from '../teacher/teacherViewModel';

export default class EventTeacherViewModel {
  eventId: number;
  id: number;
  idEntity: string;
  idNavigation?: EventViewModel;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherViewModel;

  constructor() {
    this.eventId = 0;
    this.id = 0;
    this.idEntity = '';
    this.idNavigation = undefined;
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
    <Hash>7485e0422af85ff060af33734e66d4a4</Hash>
</Codenesium>*/