export class ApiAdminRequestModel {
				birthday:string;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;

		
				}
			}

			export class ApiAdminResponseModel {
				birthday:string;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;

		
				}
			}
			export class ApiEventRequestModel {
				actualEndDate:string;
actualStartDate:string;
billAmount:number;
eventStatusId:number;
id:number;
scheduledEndDate:string;
scheduledStartDate:string;
studentNote:string;
teacherNote:string;

	
				constructor() {
					this.actualEndDate = '';
this.actualStartDate = '';
this.billAmount = 0;
this.eventStatusId = 0;
this.id = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.studentNote = '';
this.teacherNote = '';

		
				}
			}

			export class ApiEventResponseModel {
				actualEndDate:string;
actualStartDate:string;
billAmount:number;
eventStatusId:number;
id:number;
scheduledEndDate:string;
scheduledStartDate:string;
studentNote:string;
teacherNote:string;

	
				constructor() {
					this.actualEndDate = '';
this.actualStartDate = '';
this.billAmount = 0;
this.eventStatusId = 0;
this.id = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.studentNote = '';
this.teacherNote = '';

		
				}
			}
			export class ApiEventStatusRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiEventStatusResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiEventStudentRequestModel {
				eventId:number;
eventIdEntity:number;
id:number;
studentId:number;
studentIdEntity:number;

	
				constructor() {
					this.eventId = 0;
this.id = 0;
this.studentId = 0;

		
				}
			}

			export class ApiEventStudentResponseModel {
				eventId:number;
eventIdEntity:number;
id:number;
studentId:number;
studentIdEntity:number;

	
				constructor() {
					this.eventId = 0;
this.id = 0;
this.studentId = 0;

		
				}
			}
			export class ApiEventTeacherRequestModel {
				eventId:number;
eventIdEntity:number;
id:number;

	
				constructor() {
					this.eventId = 0;
this.id = 0;

		
				}
			}

			export class ApiEventTeacherResponseModel {
				eventId:number;
eventIdEntity:number;
id:number;

	
				constructor() {
					this.eventId = 0;
this.id = 0;

		
				}
			}
			export class ApiFamilyRequestModel {
				id:number;
note:string;
primaryContactEmail:string;
primaryContactFirstName:string;
primaryContactLastName:string;
primaryContactPhone:string;

	
				constructor() {
					this.id = 0;
this.note = '';
this.primaryContactEmail = '';
this.primaryContactFirstName = '';
this.primaryContactLastName = '';
this.primaryContactPhone = '';

		
				}
			}

			export class ApiFamilyResponseModel {
				id:number;
note:string;
primaryContactEmail:string;
primaryContactFirstName:string;
primaryContactLastName:string;
primaryContactPhone:string;

	
				constructor() {
					this.id = 0;
this.note = '';
this.primaryContactEmail = '';
this.primaryContactFirstName = '';
this.primaryContactLastName = '';
this.primaryContactPhone = '';

		
				}
			}
			export class ApiRateRequestModel {
				amountPerMinute:number;
id:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;

	
				constructor() {
					this.amountPerMinute = 0;
this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;

		
				}
			}

			export class ApiRateResponseModel {
				amountPerMinute:number;
id:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;

	
				constructor() {
					this.amountPerMinute = 0;
this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;

		
				}
			}
			export class ApiSpaceRequestModel {
				description:string;
id:number;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.name = '';

		
				}
			}

			export class ApiSpaceResponseModel {
				description:string;
id:number;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.name = '';

		
				}
			}
			export class ApiSpaceFeatureRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiSpaceFeatureResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiSpaceSpaceFeatureRequestModel {
				id:number;
spaceFeatureId:number;
spaceFeatureIdEntity:number;
spaceId:number;
spaceIdEntity:number;

	
				constructor() {
					this.id = 0;
this.spaceFeatureId = 0;
this.spaceId = 0;

		
				}
			}

			export class ApiSpaceSpaceFeatureResponseModel {
				id:number;
spaceFeatureId:number;
spaceFeatureIdEntity:number;
spaceId:number;
spaceIdEntity:number;

	
				constructor() {
					this.id = 0;
this.spaceFeatureId = 0;
this.spaceId = 0;

		
				}
			}
			export class ApiStudentRequestModel {
				birthday:string;
email:string;
emailRemindersEnabled:boolean;
familyId:number;
familyIdEntity:number;
firstName:string;
id:number;
isAdult:boolean;
lastName:string;
phone:string;
smsRemindersEnabled:boolean;
userId:number;
userIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.emailRemindersEnabled = false;
this.familyId = 0;
this.firstName = '';
this.id = 0;
this.isAdult = false;
this.lastName = '';
this.phone = '';
this.smsRemindersEnabled = false;
this.userId = 0;

		
				}
			}

			export class ApiStudentResponseModel {
				birthday:string;
email:string;
emailRemindersEnabled:boolean;
familyId:number;
familyIdEntity:number;
firstName:string;
id:number;
isAdult:boolean;
lastName:string;
phone:string;
smsRemindersEnabled:boolean;
userId:number;
userIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.emailRemindersEnabled = false;
this.familyId = 0;
this.firstName = '';
this.id = 0;
this.isAdult = false;
this.lastName = '';
this.phone = '';
this.smsRemindersEnabled = false;
this.userId = 0;

		
				}
			}
			export class ApiStudioRequestModel {
				address1:string;
address2:string;
city:string;
id:number;
name:string;
province:string;
website:string;
zip:string;

	
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

			export class ApiStudioResponseModel {
				address1:string;
address2:string;
city:string;
id:number;
name:string;
province:string;
website:string;
zip:string;

	
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
			export class ApiTeacherRequestModel {
				birthday:string;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;

		
				}
			}

			export class ApiTeacherResponseModel {
				birthday:string;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;

		
				}
			}
			export class ApiTeacherSkillRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiTeacherSkillResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiTeacherTeacherSkillRequestModel {
				id:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;

	
				constructor() {
					this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;

		
				}
			}

			export class ApiTeacherTeacherSkillResponseModel {
				id:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;

	
				constructor() {
					this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;

		
				}
			}
			export class ApiTenantRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiTenantResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiUserRequestModel {
				id:number;
password:string;
username:string;

	
				constructor() {
					this.id = 0;
this.password = '';
this.username = '';

		
				}
			}

			export class ApiUserResponseModel {
				id:number;
password:string;
username:string;

	
				constructor() {
					this.id = 0;
this.password = '';
this.username = '';

		
				}
			}