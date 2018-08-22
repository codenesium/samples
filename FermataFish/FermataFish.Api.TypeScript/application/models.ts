export class ApiAdminRequestModel {
				id:number;
birthday:string;
email:string;
firstName:string;
lastName:string;
phone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.birthday = '';
this.email = '';
this.firstName = '';
this.lastName = '';
this.phone = '';
this.studioId = 0;

		
				}
			}

			export class ApiAdminResponseModel {
				id:number;
birthday:string;
email:string;
firstName:string;
lastName:string;
phone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.birthday = '';
this.email = '';
this.firstName = '';
this.lastName = '';
this.phone = '';
this.studioId = 0;

		
				}
			}
			export class ApiFamilyRequestModel {
				id:number;
idEntity:number;
note:string;
pcEmail:string;
pcFirstName:string;
pcLastName:string;
pcPhone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.note = '';
this.pcEmail = '';
this.pcFirstName = '';
this.pcLastName = '';
this.pcPhone = '';
this.studioId = 0;

		
				}
			}

			export class ApiFamilyResponseModel {
				id:number;
idEntity:number;
note:string;
pcEmail:string;
pcFirstName:string;
pcLastName:string;
pcPhone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.note = '';
this.pcEmail = '';
this.pcFirstName = '';
this.pcLastName = '';
this.pcPhone = '';
this.studioId = 0;

		
				}
			}
			export class ApiLessonRequestModel {
				id:number;
actualEndDate:string;
actualStartDate:string;
billAmount:number;
lessonStatusId:number;
scheduledEndDate:string;
scheduledStartDate:string;
studentNote:string;
teacherNote:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.actualEndDate = '';
this.actualStartDate = '';
this.billAmount = 0;
this.lessonStatusId = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.studentNote = '';
this.teacherNote = '';
this.studioId = 0;

		
				}
			}

			export class ApiLessonResponseModel {
				id:number;
actualEndDate:string;
actualStartDate:string;
billAmount:number;
lessonStatusId:number;
scheduledEndDate:string;
scheduledStartDate:string;
studentNote:string;
teacherNote:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.actualEndDate = '';
this.actualStartDate = '';
this.billAmount = 0;
this.lessonStatusId = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.studentNote = '';
this.teacherNote = '';
this.studioId = 0;

		
				}
			}
			export class ApiLessonStatusRequestModel {
				id:number;
idEntity:number;
name:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.studioId = 0;

		
				}
			}

			export class ApiLessonStatusResponseModel {
				id:number;
idEntity:number;
name:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.studioId = 0;

		
				}
			}
			export class ApiLessonXStudentRequestModel {
				id:number;
lessonId:number;
lessonIdEntity:number;
studentId:number;
studentIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.lessonId = 0;
this.studentId = 0;
this.studioId = 0;

		
				}
			}

			export class ApiLessonXStudentResponseModel {
				id:number;
lessonId:number;
lessonIdEntity:number;
studentId:number;
studentIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.lessonId = 0;
this.studentId = 0;
this.studioId = 0;

		
				}
			}
			export class ApiLessonXTeacherRequestModel {
				id:number;
lessonId:number;
lessonIdEntity:number;
studentId:number;
studentIdEntity:number;

	
				constructor() {
					this.id = 0;
this.lessonId = 0;
this.studentId = 0;

		
				}
			}

			export class ApiLessonXTeacherResponseModel {
				id:number;
lessonId:number;
lessonIdEntity:number;
studentId:number;
studentIdEntity:number;

	
				constructor() {
					this.id = 0;
this.lessonId = 0;
this.studentId = 0;

		
				}
			}
			export class ApiRateRequestModel {
				id:number;
amountPerMinute:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.amountPerMinute = 0;
this.teacherId = 0;
this.teacherSkillId = 0;
this.studioId = 0;

		
				}
			}

			export class ApiRateResponseModel {
				id:number;
amountPerMinute:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.amountPerMinute = 0;
this.teacherId = 0;
this.teacherSkillId = 0;
this.studioId = 0;

		
				}
			}
			export class ApiSpaceRequestModel {
				id:number;
description:string;
name:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.description = '';
this.name = '';
this.studioId = 0;

		
				}
			}

			export class ApiSpaceResponseModel {
				id:number;
description:string;
name:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.description = '';
this.name = '';
this.studioId = 0;

		
				}
			}
			export class ApiSpaceFeatureRequestModel {
				id:number;
name:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.studioId = 0;

		
				}
			}

			export class ApiSpaceFeatureResponseModel {
				id:number;
name:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.studioId = 0;

		
				}
			}
			export class ApiSpaceXSpaceFeatureRequestModel {
				id:number;
spaceFeatureId:number;
spaceFeatureIdEntity:number;
spaceId:number;
spaceIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.spaceFeatureId = 0;
this.spaceId = 0;
this.studioId = 0;

		
				}
			}

			export class ApiSpaceXSpaceFeatureResponseModel {
				id:number;
spaceFeatureId:number;
spaceFeatureIdEntity:number;
spaceId:number;
spaceIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.spaceFeatureId = 0;
this.spaceId = 0;
this.studioId = 0;

		
				}
			}
			export class ApiStudentRequestModel {
				id:number;
birthday:string;
email:string;
emailRemindersEnabled:boolean;
familyId:number;
familyIdEntity:number;
firstName:string;
isAdult:boolean;
lastName:string;
phone:string;
smsRemindersEnabled:boolean;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.birthday = '';
this.email = '';
this.emailRemindersEnabled = false;
this.familyId = 0;
this.firstName = '';
this.isAdult = false;
this.lastName = '';
this.phone = '';
this.smsRemindersEnabled = false;
this.studioId = 0;

		
				}
			}

			export class ApiStudentResponseModel {
				id:number;
birthday:string;
email:string;
emailRemindersEnabled:boolean;
familyId:number;
familyIdEntity:number;
firstName:string;
isAdult:boolean;
lastName:string;
phone:string;
smsRemindersEnabled:boolean;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.birthday = '';
this.email = '';
this.emailRemindersEnabled = false;
this.familyId = 0;
this.firstName = '';
this.isAdult = false;
this.lastName = '';
this.phone = '';
this.smsRemindersEnabled = false;
this.studioId = 0;

		
				}
			}
			export class ApiStudentXFamilyRequestModel {
				id:number;
familyId:number;
familyIdEntity:number;
studentId:number;
studentIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.familyId = 0;
this.studentId = 0;
this.studioId = 0;

		
				}
			}

			export class ApiStudentXFamilyResponseModel {
				id:number;
familyId:number;
familyIdEntity:number;
studentId:number;
studentIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.familyId = 0;
this.studentId = 0;
this.studioId = 0;

		
				}
			}
			export class ApiStudioRequestModel {
				id:number;
address1:string;
address2:string;
city:string;
name:string;
province:string;
website:string;
zip:string;

	
				constructor() {
					this.id = 0;
this.address1 = '';
this.address2 = '';
this.city = '';
this.name = '';
this.province = '';
this.website = '';
this.zip = '';

		
				}
			}

			export class ApiStudioResponseModel {
				id:number;
address1:string;
address2:string;
city:string;
name:string;
province:string;
website:string;
zip:string;

	
				constructor() {
					this.id = 0;
this.address1 = '';
this.address2 = '';
this.city = '';
this.name = '';
this.province = '';
this.website = '';
this.zip = '';

		
				}
			}
			export class ApiTeacherRequestModel {
				id:number;
birthday:string;
email:string;
firstName:string;
lastName:string;
phone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.birthday = '';
this.email = '';
this.firstName = '';
this.lastName = '';
this.phone = '';
this.studioId = 0;

		
				}
			}

			export class ApiTeacherResponseModel {
				id:number;
birthday:string;
email:string;
firstName:string;
lastName:string;
phone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.birthday = '';
this.email = '';
this.firstName = '';
this.lastName = '';
this.phone = '';
this.studioId = 0;

		
				}
			}
			export class ApiTeacherSkillRequestModel {
				id:number;
name:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.studioId = 0;

		
				}
			}

			export class ApiTeacherSkillResponseModel {
				id:number;
name:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.studioId = 0;

		
				}
			}
			export class ApiTeacherXTeacherSkillRequestModel {
				id:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;
this.studioId = 0;

		
				}
			}

			export class ApiTeacherXTeacherSkillResponseModel {
				id:number;
teacherId:number;
teacherIdEntity:number;
teacherSkillId:number;
teacherSkillIdEntity:number;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;
this.studioId = 0;

		
				}
			}