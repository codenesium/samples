export default class RateViewModel {
    amountPerMinute:number;
id:number;
teacherId:number;
teacherIdEntity : string;
teacherSkillId:number;
teacherSkillIdEntity : string;

    constructor() {
		this.amountPerMinute = 0;
this.id = 0;
this.teacherId = 0;
this.teacherIdEntity = '';
this.teacherSkillId = 0;
this.teacherSkillIdEntity = '';

    }

	setProperties(amountPerMinute : number,id : number,isDeleted : boolean,teacherId : number,teacherSkillId : number,tenantId : number) : void
	{
		this.amountPerMinute = amountPerMinute;
this.id = id;
this.isDeleted = isDeleted;
this.teacherId = teacherId;
this.teacherSkillId = teacherSkillId;
this.tenantId = tenantId;

	}
};

/*<Codenesium>
    <Hash>de2617271c70141c7ea7d3a692c319ca</Hash>
</Codenesium>*/