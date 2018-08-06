export class ApiAdminRequestModel {
				birthday:string;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.studioId = 0;

		
				}
			}

			export class ApiAdminResponseModel {
				birthday:string;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.studioId = 0;

		
				}
			}
			export class ApiFamilyRequestModel {
				id:number;
idEntity:number;
notes:string;
pcEmail:string;
pcFirstName:string;
pcLastName:string;
pcPhone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.notes = '';
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
notes:string;
pcEmail:string;
pcFirstName:string;
pcLastName:string;
pcPhone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.id = 0;
this.notes = '';
this.pcEmail = '';
this.pcFirstName = '';
this.pcLastName = '';
this.pcPhone = '';
this.studioId = 0;

		
				}
			}
			export class ApiLessonRequestModel {
				actualEndDate:string;
actualStartDate:string;
billAmount:number;
id:number;
lessonStatusId:number;
lessonStatusIdEntity:number;
scheduledEndDate:string;
scheduledStartDate:string;
studentNotes:string;
studioId:number;
studioIdEntity:number;
teacherNotes:string;

	
				constructor() {
					this.actualEndDate = '';
this.actualStartDate = '';
this.billAmount = 0;
this.id = 0;
this.lessonStatusId = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.studentNotes = '';
this.studioId = 0;
this.teacherNotes = '';

		
				}
			}

			export class ApiLessonResponseModel {
				actualEndDate:string;
actualStartDate:string;
billAmount:number;
id:number;
lessonStatusId:number;
lessonStatusIdEntity:number;
scheduledEndDate:string;
scheduledStartDate:string;
studentNotes:string;
studioId:number;
studioIdEntity:number;
teacherNotes:string;

	
				constructor() {
					this.actualEndDate = '';
this.actualStartDate = '';
this.billAmount = 0;
this.id = 0;
this.lessonStatusId = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.studentNotes = '';
this.studioId = 0;
this.teacherNotes = '';

		
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

	
				constructor() {
					this.id = 0;
this.lessonId = 0;
this.studentId = 0;

		
				}
			}

			export class ApiLessonXStudentResponseModel {
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
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.description = '';
this.id = 0;
this.name = '';
this.studioId = 0;

		
				}
			}

			export class ApiSpaceResponseModel {
				description:string;
id:number;
name:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.description = '';
this.id = 0;
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

	
				constructor() {
					this.id = 0;
this.spaceFeatureId = 0;
this.spaceId = 0;

		
				}
			}

			export class ApiSpaceXSpaceFeatureResponseModel {
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
			export class ApiStateRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiStateResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
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
studioId:number;
studioIdEntity:number;

	
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
this.studioId = 0;

		
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
studioId:number;
studioIdEntity:number;

	
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
this.studioId = 0;

		
				}
			}
			export class ApiStudentXFamilyRequestModel {
				familyId:number;
familyIdEntity:number;
id:number;
studentId:number;
studentIdEntity:number;

	
				constructor() {
					this.familyId = 0;
this.id = 0;
this.studentId = 0;

		
				}
			}

			export class ApiStudentXFamilyResponseModel {
				familyId:number;
familyIdEntity:number;
id:number;
studentId:number;
studentIdEntity:number;

	
				constructor() {
					this.familyId = 0;
this.id = 0;
this.studentId = 0;

		
				}
			}
			export class ApiStudioRequestModel {
				address1:string;
address2:string;
city:string;
id:number;
name:string;
stateId:number;
stateIdEntity:number;
website:string;
zip:string;

	
				constructor() {
					this.address1 = '';
this.address2 = '';
this.city = '';
this.id = 0;
this.name = '';
this.stateId = 0;
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
stateId:number;
stateIdEntity:number;
website:string;
zip:string;

	
				constructor() {
					this.address1 = '';
this.address2 = '';
this.city = '';
this.id = 0;
this.name = '';
this.stateId = 0;
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
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.studioId = 0;

		
				}
			}

			export class ApiTeacherResponseModel {
				birthday:string;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
studioId:number;
studioIdEntity:number;

	
				constructor() {
					this.birthday = '';
this.email = '';
this.firstName = '';
this.id = 0;
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

	
				constructor() {
					this.id = 0;
this.teacherId = 0;
this.teacherSkillId = 0;

		
				}
			}

			export class ApiTeacherXTeacherSkillResponseModel {
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