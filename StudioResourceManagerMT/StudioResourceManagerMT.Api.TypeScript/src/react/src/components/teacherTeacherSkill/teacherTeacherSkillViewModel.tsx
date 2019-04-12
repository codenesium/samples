import moment from 'moment';
import TeacherViewModel from '../teacher/teacherViewModel';
import TeacherSkillViewModel from '../teacherSkill/teacherSkillViewModel';

export default class TeacherTeacherSkillViewModel {
  id: number;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherViewModel;
  teacherSkillId: number;
  teacherSkillIdEntity: string;
  teacherSkillIdNavigation?: TeacherSkillViewModel;

  constructor() {
    this.id = 0;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
    this.teacherSkillId = 0;
    this.teacherSkillIdEntity = '';
    this.teacherSkillIdNavigation = undefined;
  }

  setProperties(id: number, teacherId: number, teacherSkillId: number): void {
    this.id = id;
    this.teacherId = teacherId;
    this.teacherSkillId = teacherSkillId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>e9a90949f03b6a7d4179d3ff05ab32f1</Hash>
</Codenesium>*/