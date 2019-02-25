import moment from 'moment'
import TeacherViewModel from '../teacher/teacherViewModel'
	import TeacherSkillViewModel from '../teacherSkill/teacherSkillViewModel'
	

export default class RateViewModel {
    amountPerMinute:number;
id:number;
teacherId:number;
teacherIdEntity : string;
teacherIdNavigation? : TeacherViewModel;
teacherSkillId:number;
teacherSkillIdEntity : string;
teacherSkillIdNavigation? : TeacherSkillViewModel;

    constructor() {
		this.amountPerMinute = 0;
this.id = 0;
this.teacherId = 0;
this.teacherIdEntity = '';
this.teacherIdNavigation = new TeacherViewModel();
this.teacherSkillId = 0;
this.teacherSkillIdEntity = '';
this.teacherSkillIdNavigation = new TeacherSkillViewModel();

    }

	setProperties(amountPerMinute : number,id : number,teacherId : number,teacherSkillId : number) : void
	{
		this.amountPerMinute = amountPerMinute;
this.id = id;
this.teacherId = teacherId;
this.teacherSkillId = teacherSkillId;

	}

	toDisplay() : string
	{
		return String(this.id);
	}
};

/*<Codenesium>
    <Hash>81a730754ae4e197dc2b6af1ebd2ef03</Hash>
</Codenesium>*/