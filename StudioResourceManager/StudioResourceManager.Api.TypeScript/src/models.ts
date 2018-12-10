export class ApiAdminClientRequestModel {
	birthday : string;
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	phone : string;
	userId : number;
	userIdEntity : string;

	constructor() {
		this.birthday = '';
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.phone = '';
		this.userId = 0;
		this.userIdEntity = '';
	}
}

export class ApiAdminClientResponseModel {
	birthday : string;
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	phone : string;
	userId : number;
	userIdEntity : string;

	constructor() {
		this.birthday = '';
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.phone = '';
		this.userId = 0;
		this.userIdEntity = '';
	}
}
export class ApiEventClientRequestModel {
	actualEndDate : string;
	actualStartDate : string;
	billAmount : number;
	eventStatusId : number;
	eventStatusIdEntity : string;
	id : number;
	scheduledEndDate : string;
	scheduledStartDate : string;
	studentNote : string;
	teacherNote : string;

	constructor() {
		this.actualEndDate = '';
		this.actualStartDate = '';
		this.billAmount = 0;
		this.eventStatusId = 0;
		this.eventStatusIdEntity = '';
		this.id = 0;
		this.scheduledEndDate = '';
		this.scheduledStartDate = '';
		this.studentNote = '';
		this.teacherNote = '';
	}
}

export class ApiEventClientResponseModel {
	actualEndDate : string;
	actualStartDate : string;
	billAmount : number;
	eventStatusId : number;
	eventStatusIdEntity : string;
	id : number;
	scheduledEndDate : string;
	scheduledStartDate : string;
	studentNote : string;
	teacherNote : string;

	constructor() {
		this.actualEndDate = '';
		this.actualStartDate = '';
		this.billAmount = 0;
		this.eventStatusId = 0;
		this.eventStatusIdEntity = '';
		this.id = 0;
		this.scheduledEndDate = '';
		this.scheduledStartDate = '';
		this.studentNote = '';
		this.teacherNote = '';
	}
}
export class ApiEventStatuClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiEventStatuClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiFamilyClientRequestModel {
	id : number;
	note : string;
	primaryContactEmail : string;
	primaryContactFirstName : string;
	primaryContactLastName : string;
	primaryContactPhone : string;

	constructor() {
		this.id = 0;
		this.note = '';
		this.primaryContactEmail = '';
		this.primaryContactFirstName = '';
		this.primaryContactLastName = '';
		this.primaryContactPhone = '';
	}
}

export class ApiFamilyClientResponseModel {
	id : number;
	note : string;
	primaryContactEmail : string;
	primaryContactFirstName : string;
	primaryContactLastName : string;
	primaryContactPhone : string;

	constructor() {
		this.id = 0;
		this.note = '';
		this.primaryContactEmail = '';
		this.primaryContactFirstName = '';
		this.primaryContactLastName = '';
		this.primaryContactPhone = '';
	}
}
export class ApiRateClientRequestModel {
	amountPerMinute : number;
	id : number;
	teacherId : number;
	teacherIdEntity : string;
	teacherSkillId : number;
	teacherSkillIdEntity : string;

	constructor() {
		this.amountPerMinute = 0;
		this.id = 0;
		this.teacherId = 0;
		this.teacherIdEntity = '';
		this.teacherSkillId = 0;
		this.teacherSkillIdEntity = '';
	}
}

export class ApiRateClientResponseModel {
	amountPerMinute : number;
	id : number;
	teacherId : number;
	teacherIdEntity : string;
	teacherSkillId : number;
	teacherSkillIdEntity : string;

	constructor() {
		this.amountPerMinute = 0;
		this.id = 0;
		this.teacherId = 0;
		this.teacherIdEntity = '';
		this.teacherSkillId = 0;
		this.teacherSkillIdEntity = '';
	}
}
export class ApiSpaceClientRequestModel {
	description : string;
	id : number;
	name : string;

	constructor() {
		this.description = '';
		this.id = 0;
		this.name = '';
	}
}

export class ApiSpaceClientResponseModel {
	description : string;
	id : number;
	name : string;

	constructor() {
		this.description = '';
		this.id = 0;
		this.name = '';
	}
}
export class ApiSpaceFeatureClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiSpaceFeatureClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiStudentClientRequestModel {
	birthday : string;
	email : string;
	emailRemindersEnabled : boolean;
	familyId : number;
	familyIdEntity : string;
	firstName : string;
	id : number;
	isAdult : boolean;
	lastName : string;
	phone : string;
	smsRemindersEnabled : boolean;
	userId : number;
	userIdEntity : string;

	constructor() {
		this.birthday = '';
		this.email = '';
		this.emailRemindersEnabled = false;
		this.familyId = 0;
		this.familyIdEntity = '';
		this.firstName = '';
		this.id = 0;
		this.isAdult = false;
		this.lastName = '';
		this.phone = '';
		this.smsRemindersEnabled = false;
		this.userId = 0;
		this.userIdEntity = '';
	}
}

export class ApiStudentClientResponseModel {
	birthday : string;
	email : string;
	emailRemindersEnabled : boolean;
	familyId : number;
	familyIdEntity : string;
	firstName : string;
	id : number;
	isAdult : boolean;
	lastName : string;
	phone : string;
	smsRemindersEnabled : boolean;
	userId : number;
	userIdEntity : string;

	constructor() {
		this.birthday = '';
		this.email = '';
		this.emailRemindersEnabled = false;
		this.familyId = 0;
		this.familyIdEntity = '';
		this.firstName = '';
		this.id = 0;
		this.isAdult = false;
		this.lastName = '';
		this.phone = '';
		this.smsRemindersEnabled = false;
		this.userId = 0;
		this.userIdEntity = '';
	}
}
export class ApiStudioClientRequestModel {
	address1 : string;
	address2 : string;
	city : string;
	id : number;
	name : string;
	province : string;
	website : string;
	zip : string;

	constructor() {
		this.address1 = '';
		this.address2 = '';
		this.city = '';
		this.id = 0;
		this.name = '';
		this.province = '';
		this.website = '';
		this.zip = '';
	}
}

export class ApiStudioClientResponseModel {
	address1 : string;
	address2 : string;
	city : string;
	id : number;
	name : string;
	province : string;
	website : string;
	zip : string;

	constructor() {
		this.address1 = '';
		this.address2 = '';
		this.city = '';
		this.id = 0;
		this.name = '';
		this.province = '';
		this.website = '';
		this.zip = '';
	}
}
export class ApiTeacherClientRequestModel {
	birthday : string;
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	phone : string;
	userId : number;
	userIdEntity : string;

	constructor() {
		this.birthday = '';
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.phone = '';
		this.userId = 0;
		this.userIdEntity = '';
	}
}

export class ApiTeacherClientResponseModel {
	birthday : string;
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	phone : string;
	userId : number;
	userIdEntity : string;

	constructor() {
		this.birthday = '';
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.phone = '';
		this.userId = 0;
		this.userIdEntity = '';
	}
}
export class ApiTeacherSkillClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiTeacherSkillClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiUserClientRequestModel {
	id : number;
	password : string;
	username : string;

	constructor() {
		this.id = 0;
		this.password = '';
		this.username = '';
	}
}

export class ApiUserClientResponseModel {
	id : number;
	password : string;
	username : string;

	constructor() {
		this.id = 0;
		this.password = '';
		this.username = '';
	}
}

/*<Codenesium>
    <Hash>850b0975b842dbbdbe92eeff1f8c5a4c</Hash>
</Codenesium>*/