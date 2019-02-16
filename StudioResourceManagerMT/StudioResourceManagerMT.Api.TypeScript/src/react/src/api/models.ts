export class AdminClientRequestModel {
				birthday:any;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity : string;

	
				constructor() {
					this.birthday = undefined;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;
this.userIdEntity = '';

				}

				setProperties(birthday : any,email : string,firstName : string,id : number,isDeleted : boolean,lastName : string,phone : string,tenantId : number,userId : number) : void
				{
					this.birthday = birthday;
this.email = email;
this.firstName = firstName;
this.id = id;
this.isDeleted = isDeleted;
this.lastName = lastName;
this.phone = phone;
this.tenantId = tenantId;
this.userId = userId;

				}
			}

			export class AdminClientResponseModel {
				birthday:any;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity : string;

	
				constructor() {
					this.birthday = undefined;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;
this.userIdEntity = '';

				}

				setProperties(birthday : any,email : string,firstName : string,id : number,isDeleted : boolean,lastName : string,phone : string,tenantId : number,userId : number) : void
				{
					this.birthday = birthday;
this.email = email;
this.firstName = firstName;
this.id = id;
this.isDeleted = isDeleted;
this.lastName = lastName;
this.phone = phone;
this.tenantId = tenantId;
this.userId = userId;

				}
			}
			export class EventClientRequestModel {
				actualEndDate:any;
actualStartDate:any;
billAmount:any;
eventStatusId:number;
eventStatusIdEntity : string;
id:number;
scheduledEndDate:any;
scheduledStartDate:any;
studentNote:string;
teacherNote:string;

	
				constructor() {
					this.actualEndDate = undefined;
this.actualStartDate = undefined;
this.billAmount = undefined;
this.eventStatusId = 0;
this.eventStatusIdEntity = '';
this.id = 0;
this.scheduledEndDate = undefined;
this.scheduledStartDate = undefined;
this.studentNote = '';
this.teacherNote = '';

				}

				setProperties(actualEndDate : any,actualStartDate : any,billAmount : any,eventStatusId : number,id : number,isDeleted : boolean,scheduledEndDate : any,scheduledStartDate : any,studentNote : string,teacherNote : string,tenantId : number) : void
				{
					this.actualEndDate = actualEndDate;
this.actualStartDate = actualStartDate;
this.billAmount = billAmount;
this.eventStatusId = eventStatusId;
this.id = id;
this.isDeleted = isDeleted;
this.scheduledEndDate = scheduledEndDate;
this.scheduledStartDate = scheduledStartDate;
this.studentNote = studentNote;
this.teacherNote = teacherNote;
this.tenantId = tenantId;

				}
			}

			export class EventClientResponseModel {
				actualEndDate:any;
actualStartDate:any;
billAmount:any;
eventStatusId:number;
eventStatusIdEntity : string;
id:number;
scheduledEndDate:any;
scheduledStartDate:any;
studentNote:string;
teacherNote:string;

	
				constructor() {
					this.actualEndDate = undefined;
this.actualStartDate = undefined;
this.billAmount = undefined;
this.eventStatusId = 0;
this.eventStatusIdEntity = '';
this.id = 0;
this.scheduledEndDate = undefined;
this.scheduledStartDate = undefined;
this.studentNote = '';
this.teacherNote = '';

				}

				setProperties(actualEndDate : any,actualStartDate : any,billAmount : any,eventStatusId : number,id : number,isDeleted : boolean,scheduledEndDate : any,scheduledStartDate : any,studentNote : string,teacherNote : string,tenantId : number) : void
				{
					this.actualEndDate = actualEndDate;
this.actualStartDate = actualStartDate;
this.billAmount = billAmount;
this.eventStatusId = eventStatusId;
this.id = id;
this.isDeleted = isDeleted;
this.scheduledEndDate = scheduledEndDate;
this.scheduledStartDate = scheduledStartDate;
this.studentNote = studentNote;
this.teacherNote = teacherNote;
this.tenantId = tenantId;

				}
			}
			export class EventStatuClientRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,isDeleted : boolean,name : string,tenantId : number) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.tenantId = tenantId;

				}
			}

			export class EventStatuClientResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,isDeleted : boolean,name : string,tenantId : number) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.tenantId = tenantId;

				}
			}
			export class FamilyClientRequestModel {
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

				setProperties(id : number,isDeleted : boolean,note : string,primaryContactEmail : string,primaryContactFirstName : string,primaryContactLastName : string,primaryContactPhone : string,tenantId : number) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.note = note;
this.primaryContactEmail = primaryContactEmail;
this.primaryContactFirstName = primaryContactFirstName;
this.primaryContactLastName = primaryContactLastName;
this.primaryContactPhone = primaryContactPhone;
this.tenantId = tenantId;

				}
			}

			export class FamilyClientResponseModel {
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

				setProperties(id : number,isDeleted : boolean,note : string,primaryContactEmail : string,primaryContactFirstName : string,primaryContactLastName : string,primaryContactPhone : string,tenantId : number) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.note = note;
this.primaryContactEmail = primaryContactEmail;
this.primaryContactFirstName = primaryContactFirstName;
this.primaryContactLastName = primaryContactLastName;
this.primaryContactPhone = primaryContactPhone;
this.tenantId = tenantId;

				}
			}
			export class RateClientRequestModel {
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
			}

			export class RateClientResponseModel {
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
			}
			export class SpaceClientRequestModel {
				description:string;
id:number;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.name = '';

				}

				setProperties(description : string,id : number,isDeleted : boolean,name : string,tenantId : number) : void
				{
					this.description = description;
this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.tenantId = tenantId;

				}
			}

			export class SpaceClientResponseModel {
				description:string;
id:number;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.name = '';

				}

				setProperties(description : string,id : number,isDeleted : boolean,name : string,tenantId : number) : void
				{
					this.description = description;
this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.tenantId = tenantId;

				}
			}
			export class SpaceFeatureClientRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,isDeleted : boolean,name : string,tenantId : number) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.tenantId = tenantId;

				}
			}

			export class SpaceFeatureClientResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,isDeleted : boolean,name : string,tenantId : number) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.tenantId = tenantId;

				}
			}
			export class StudentClientRequestModel {
				birthday:any;
email:string;
emailRemindersEnabled:boolean;
familyId:number;
familyIdEntity : string;
firstName:string;
id:number;
isAdult:boolean;
lastName:string;
phone:string;
smsRemindersEnabled:boolean;
userId:number;
userIdEntity : string;

	
				constructor() {
					this.birthday = undefined;
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

				setProperties(birthday : any,email : string,emailRemindersEnabled : boolean,familyId : number,firstName : string,id : number,isAdult : boolean,isDeleted : boolean,lastName : string,phone : string,smsRemindersEnabled : boolean,tenantId : number,userId : number) : void
				{
					this.birthday = birthday;
this.email = email;
this.emailRemindersEnabled = emailRemindersEnabled;
this.familyId = familyId;
this.firstName = firstName;
this.id = id;
this.isAdult = isAdult;
this.isDeleted = isDeleted;
this.lastName = lastName;
this.phone = phone;
this.smsRemindersEnabled = smsRemindersEnabled;
this.tenantId = tenantId;
this.userId = userId;

				}
			}

			export class StudentClientResponseModel {
				birthday:any;
email:string;
emailRemindersEnabled:boolean;
familyId:number;
familyIdEntity : string;
firstName:string;
id:number;
isAdult:boolean;
lastName:string;
phone:string;
smsRemindersEnabled:boolean;
userId:number;
userIdEntity : string;

	
				constructor() {
					this.birthday = undefined;
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

				setProperties(birthday : any,email : string,emailRemindersEnabled : boolean,familyId : number,firstName : string,id : number,isAdult : boolean,isDeleted : boolean,lastName : string,phone : string,smsRemindersEnabled : boolean,tenantId : number,userId : number) : void
				{
					this.birthday = birthday;
this.email = email;
this.emailRemindersEnabled = emailRemindersEnabled;
this.familyId = familyId;
this.firstName = firstName;
this.id = id;
this.isAdult = isAdult;
this.isDeleted = isDeleted;
this.lastName = lastName;
this.phone = phone;
this.smsRemindersEnabled = smsRemindersEnabled;
this.tenantId = tenantId;
this.userId = userId;

				}
			}
			export class StudioClientRequestModel {
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

				setProperties(address1 : string,address2 : string,city : string,id : number,isDeleted : boolean,name : string,province : string,tenantId : number,website : string,zip : string) : void
				{
					this.address1 = address1;
this.address2 = address2;
this.city = city;
this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.province = province;
this.tenantId = tenantId;
this.website = website;
this.zip = zip;

				}
			}

			export class StudioClientResponseModel {
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

				setProperties(address1 : string,address2 : string,city : string,id : number,isDeleted : boolean,name : string,province : string,tenantId : number,website : string,zip : string) : void
				{
					this.address1 = address1;
this.address2 = address2;
this.city = city;
this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.province = province;
this.tenantId = tenantId;
this.website = website;
this.zip = zip;

				}
			}
			export class TeacherClientRequestModel {
				birthday:any;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity : string;

	
				constructor() {
					this.birthday = undefined;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;
this.userIdEntity = '';

				}

				setProperties(birthday : any,email : string,firstName : string,id : number,isDeleted : boolean,lastName : string,phone : string,tenantId : number,userId : number) : void
				{
					this.birthday = birthday;
this.email = email;
this.firstName = firstName;
this.id = id;
this.isDeleted = isDeleted;
this.lastName = lastName;
this.phone = phone;
this.tenantId = tenantId;
this.userId = userId;

				}
			}

			export class TeacherClientResponseModel {
				birthday:any;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;
userId:number;
userIdEntity : string;

	
				constructor() {
					this.birthday = undefined;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';
this.userId = 0;
this.userIdEntity = '';

				}

				setProperties(birthday : any,email : string,firstName : string,id : number,isDeleted : boolean,lastName : string,phone : string,tenantId : number,userId : number) : void
				{
					this.birthday = birthday;
this.email = email;
this.firstName = firstName;
this.id = id;
this.isDeleted = isDeleted;
this.lastName = lastName;
this.phone = phone;
this.tenantId = tenantId;
this.userId = userId;

				}
			}
			export class TeacherSkillClientRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,isDeleted : boolean,name : string,tenantId : number) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.tenantId = tenantId;

				}
			}

			export class TeacherSkillClientResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,isDeleted : boolean,name : string,tenantId : number) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.tenantId = tenantId;

				}
			}
			export class UserClientRequestModel {
				id:number;
password:string;
username:string;

	
				constructor() {
					this.id = 0;
this.password = '';
this.username = '';

				}

				setProperties(id : number,isDeleted : boolean,password : string,tenantId : number,username : string) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.password = password;
this.tenantId = tenantId;
this.username = username;

				}
			}

			export class UserClientResponseModel {
				id:number;
password:string;
username:string;

	
				constructor() {
					this.id = 0;
this.password = '';
this.username = '';

				}

				setProperties(id : number,isDeleted : boolean,password : string,tenantId : number,username : string) : void
				{
					this.id = id;
this.isDeleted = isDeleted;
this.password = password;
this.tenantId = tenantId;
this.username = username;

				}
			}

/*<Codenesium>
    <Hash>2f180cf82d3f5fcd0f070e44daaadfa7</Hash>
</Codenesium>*/