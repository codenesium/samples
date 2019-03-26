import moment from 'moment';
import EventViewModel from '../event/eventViewModel';
import TeacherViewModel from '../teacher/teacherViewModel';

export default class EventTeacherViewModel {
  id: number;
  idEntity: string;
  idNavigation?: EventViewModel;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherViewModel;

  constructor() {
    this.id = 0;
    this.idEntity = '';
    this.idNavigation = undefined;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
  }

  setProperties(id: number, teacherId: number): void {
    this.id = id;
    this.teacherId = teacherId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>1da16fb1f6f8017301230043d862cf19</Hash>
</Codenesium>*/