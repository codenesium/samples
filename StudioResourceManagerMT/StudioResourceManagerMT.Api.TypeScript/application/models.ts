export class ApiAdminServerRequestModel {
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

			export class ApiAdminServerResponseModel {
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
			export class ApiEventServerRequestModel {
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

			export class ApiEventServerResponseModel {
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
			export class ApiEventStatuServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiEventStatuServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiFamilyServerRequestModel {
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

			export class ApiFamilyServerResponseModel {
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
			export class ApiRateServerRequestModel {
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

			export class ApiRateServerResponseModel {
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
			export class ApiSpaceServerRequestModel {
				description:string;
id:number;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.name = '';

		
				}
			}

			export class ApiSpaceServerResponseModel {
				description:string;
id:number;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.name = '';

		
				}
			}
			export class ApiSpaceFeatureServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiSpaceFeatureServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiStudentServerRequestModel {
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

			export class ApiStudentServerResponseModel {
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
			export class ApiStudioServerRequestModel {
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

			export class ApiStudioServerResponseModel {
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
			export class ApiTeacherServerRequestModel {
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

			export class ApiTeacherServerResponseModel {
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
			export class ApiTeacherSkillServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiTeacherSkillServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiUserServerRequestModel {
				id:number;
password:string;
username:string;

	
				constructor() {
					this.id = 0;
this.password = '';
this.username = '';

		
				}
			}

			export class ApiUserServerResponseModel {
				id:number;
password:string;
username:string;

	
				constructor() {
					this.id = 0;
this.password = '';
this.username = '';

		
				}
			}