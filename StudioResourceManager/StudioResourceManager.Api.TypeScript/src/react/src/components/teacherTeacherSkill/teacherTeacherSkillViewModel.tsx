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
    return String(this.teacherId);
  }
}


/*<Codenesium>
    <Hash>5e6a4b9357ccad5f2e5b41cb2e2ff367</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/