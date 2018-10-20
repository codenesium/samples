export class ApiAdminRequestModel {
				birthday:string;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;
this.isDeleted = false;

		
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
isDeleted:boolean;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;
this.isDeleted = false;

		
				}
			}
			export class ApiEventRequestModel {
				actualEndDate:string;
actualStartDate:string;
billAmount:number;
eventStatusId:number;
eventStatusIdEntity:number;
id:number;
scheduledEndDate:string;
scheduledStartDate:string;
studentNote:string;
teacherNote:string;
isDeleted:boolean;

	
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
this.isDeleted = false;

		
				}
			}

			export class ApiEventResponseModel {
				actualEndDate:string;
actualStartDate:string;
billAmount:number;
eventStatusId:number;
eventStatusIdEntity:number;
id:number;
scheduledEndDate:string;
scheduledStartDate:string;
studentNote:string;
teacherNote:string;
isDeleted:boolean;

	
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
this.isDeleted = false;

		
				}
			}
			export class ApiEventStatusRequestModel {
				id:number;
name:string;
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.name = '';
this.isDeleted = false;

		
				}
			}

			export class ApiEventStatusResponseModel {
				id:number;
name:string;
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.name = '';
this.isDeleted = false;

		
				}
			}
			export class ApiEventStudentRequestModel {
				eventId:number;
eventIdEntity:number;
studentId:number;
studentIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.eventId = 0;
this.studentId = 0;
this.isDeleted = false;

		
				}
			}

			export class ApiEventStudentResponseModel {
				eventId:number;
eventIdEntity:number;
studentId:number;
studentIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.eventId = 0;
this.studentId = 0;
this.isDeleted = false;

		
				}
			}
			export class ApiEventTeacherRequestModel {
				eventId:number;
eventIdEntity:number;
teacherId:number;
teacherIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.eventId = 0;
this.teacherId = 0;
this.isDeleted = false;

		
				}
			}

			export class ApiEventTeacherResponseModel {
				eventId:number;
eventIdEntity:number;
teacherId:number;
teacherIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.eventId = 0;
this.teacherId = 0;
this.isDeleted = false;

		
				}
			}
			export class ApiFamilyRequestModel {
				id:number;
note:string;
primaryContactEmail:string;
primaryContactFirstName:string;
primaryContactLastName:string;
primaryContactPhone:string;
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.note = '';
this.primaryContactEmail = '';
this.primaryContactFirstName = '';
this.primaryContactLastName = '';
this.primaryContactPhone = '';
this.isDeleted = false;

		
				}
			}

			export class ApiFamilyResponseModel {
				id:number;
note:string;
primaryContactEmail:string;
primaryContactFirstName:string;
primaryContactLastName:string;
primaryContactPhone:string;
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.note = '';
this.primaryContactEmail = '';
this.primaryContactFirstName = '';
this.primaryContactLastName = '';
this.primaryContactPhone = '';
this.isDeleted = false;

		
				}
			}
			export class ApiRateRequestModel {
				amountPerMinute:number;
id:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.amountPerMinute = 0;
this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;
this.isDeleted = false;

		
				}
			}

			export class ApiRateResponseModel {
				amountPerMinute:number;
id:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.amountPerMinute = 0;
this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;
this.isDeleted = false;

		
				}
			}
			export class ApiSpaceRequestModel {
				description:string;
id:number;
name:string;
isDeleted:boolean;

	
				constructor() {
					this.description = '';
this.id = 0;
this.name = '';
this.isDeleted = false;

		
				}
			}

			export class ApiSpaceResponseModel {
				description:string;
id:number;
name:string;
isDeleted:boolean;

	
				constructor() {
					this.description = '';
this.id = 0;
this.name = '';
this.isDeleted = false;

		
				}
			}
			export class ApiSpaceFeatureRequestModel {
				id:number;
name:string;
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.name = '';
this.isDeleted = false;

		
				}
			}

			export class ApiSpaceFeatureResponseModel {
				id:number;
name:string;
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.name = '';
this.isDeleted = false;

		
				}
			}
			export class ApiSpaceSpaceFeatureRequestModel {
				spaceFeatureId:number;
spaceFeatureIdEntity:number;
spaceId:number;
spaceIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.spaceFeatureId = 0;
this.spaceId = 0;
this.isDeleted = false;

		
				}
			}

			export class ApiSpaceSpaceFeatureResponseModel {
				spaceFeatureId:number;
spaceFeatureIdEntity:number;
spaceId:number;
spaceIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.spaceFeatureId = 0;
this.spaceId = 0;
this.isDeleted = false;

		
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
isDeleted:boolean;

	
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
this.isDeleted = false;

		
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
isDeleted:boolean;

	
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
this.isDeleted = false;

		
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
isDeleted:boolean;

	
				constructor() {
					this.address1 = '';
this.address2 = '';
this.city = '';
this.id = 0;
this.name = '';
this.province = '';
this.website = '';
this.zip = '';
this.isDeleted = false;

		
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
isDeleted:boolean;

	
				constructor() {
					this.address1 = '';
this.address2 = '';
this.city = '';
this.id = 0;
this.name = '';
this.province = '';
this.website = '';
this.zip = '';
this.isDeleted = false;

		
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
isDeleted:boolean;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;
this.isDeleted = false;

		
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
isDeleted:boolean;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;
this.isDeleted = false;

		
				}
			}
			export class ApiTeacherSkillRequestModel {
				id:number;
name:string;
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.name = '';
this.isDeleted = false;

		
				}
			}

			export class ApiTeacherSkillResponseModel {
				id:number;
name:string;
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.name = '';
this.isDeleted = false;

		
				}
			}
			export class ApiTeacherTeacherSkillRequestModel {
				teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.teacherId = 0;
this.teacherSkillId = 0;
this.isDeleted = false;

		
				}
			}

			export class ApiTeacherTeacherSkillResponseModel {
				teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;
isDeleted:boolean;

	
				constructor() {
					this.teacherId = 0;
this.teacherSkillId = 0;
this.isDeleted = false;

		
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
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.password = '';
this.username = '';
this.isDeleted = false;

		
				}
			}

			export class ApiUserResponseModel {
				id:number;
password:string;
username:string;
isDeleted:boolean;

	
				constructor() {
					this.id = 0;
this.password = '';
this.username = '';
this.isDeleted = false;

		
				}
			}
			export class ApiVEventRequestModel {
				actualEndDate:string;
actualStartDate:string;
billAmount:number;
eventStatusId:number;
id:number;
scheduledEndDate:string;
scheduledStartDate:string;
isDeleted:boolean;

	
				constructor() {
					this.actualEndDate = '';
this.actualStartDate = '';
this.billAmount = 0;
this.eventStatusId = 0;
this.id = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.isDeleted = false;

		
				}
			}

			export class ApiVEventResponseModel {
				actualEndDate:string;
actualStartDate:string;
billAmount:number;
eventStatusId:number;
id:number;
scheduledEndDate:string;
scheduledStartDate:string;
isDeleted:boolean;

	
				constructor() {
					this.actualEndDate = '';
this.actualStartDate = '';
this.billAmount = 0;
this.eventStatusId = 0;
this.id = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.isDeleted = false;

		
				}
			}