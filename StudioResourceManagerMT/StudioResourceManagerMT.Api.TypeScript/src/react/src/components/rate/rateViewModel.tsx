import moment from 'moment'


export default class RateViewModel {
    amountPerMinute:number;
id:number;
teacherId:number;
teacherSkillId:number;

    constructor() {
		this.amountPerMinute = 0;
this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;

    }

	setProperties(amountPerMinute : number,id : number,teacherId : number,teacherSkillId : number) : void
	{
		this.amountPerMinute = moment(amountPerMinute,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.teacherId = moment(teacherId,'YYYY-MM-DD');
this.teacherSkillId = moment(teacherSkillId,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>5828f2109cd02a161fca77dddbfef905</Hash>
</Codenesium>*/