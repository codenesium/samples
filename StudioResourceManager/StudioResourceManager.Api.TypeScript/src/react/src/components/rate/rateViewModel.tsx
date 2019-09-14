import moment from 'moment';
import TeacherViewModel from '../teacher/teacherViewModel';
import TeacherSkillViewModel from '../teacherSkill/teacherSkillViewModel';

export default class RateViewModel {
  amountPerMinute: number;
  id: number;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherViewModel;
  teacherSkillId: number;
  teacherSkillIdEntity: string;
  teacherSkillIdNavigation?: TeacherSkillViewModel;

  constructor() {
    this.amountPerMinute = 0;
    this.id = 0;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
    this.teacherSkillId = 0;
    this.teacherSkillIdEntity = '';
    this.teacherSkillIdNavigation = undefined;
  }

  setProperties(
    amountPerMinute: number,
    id: number,
    teacherId: number,
    teacherSkillId: number
  ): void {
    this.amountPerMinute = amountPerMinute;
    this.id = id;
    this.teacherId = teacherId;
    this.teacherSkillId = teacherSkillId;
  }

  toDisplay(): string {
    return String(this.amountPerMinute);
  }
}


/*<Codenesium>
    <Hash>8a89a4916657af45ca43083c2eb81605</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/