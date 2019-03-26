export class AdminClientRequestModel {
  birthday: any;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.birthday = undefined;
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    birthday: any,
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    phone: string,
    userId: number
  ): void {
    this.birthday = birthday;
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
    this.userId = userId;
  }
}

export class AdminClientResponseModel {
  birthday: any;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.birthday = undefined;
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    birthday: any,
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    phone: string,
    userId: number
  ): void {
    this.birthday = birthday;
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
    this.userId = userId;
  }
}
export class EventClientRequestModel {
  actualEndDate: any;
  actualStartDate: any;
  billAmount: number;
  eventStatusId: number;
  eventStatusIdEntity: string;
  eventStatusIdNavigation?: EventStatusClientResponseModel;
  id: number;
  scheduledEndDate: any;
  scheduledStartDate: any;
  studentNote: string;
  teacherNote: string;

  constructor() {
    this.actualEndDate = undefined;
    this.actualStartDate = undefined;
    this.billAmount = 0;
    this.eventStatusId = 0;
    this.eventStatusIdEntity = '';
    this.eventStatusIdNavigation = undefined;
    this.id = 0;
    this.scheduledEndDate = undefined;
    this.scheduledStartDate = undefined;
    this.studentNote = '';
    this.teacherNote = '';
  }

  setProperties(
    actualEndDate: any,
    actualStartDate: any,
    billAmount: number,
    eventStatusId: number,
    id: number,
    scheduledEndDate: any,
    scheduledStartDate: any,
    studentNote: string,
    teacherNote: string
  ): void {
    this.actualEndDate = actualEndDate;
    this.actualStartDate = actualStartDate;
    this.billAmount = billAmount;
    this.eventStatusId = eventStatusId;
    this.id = id;
    this.scheduledEndDate = scheduledEndDate;
    this.scheduledStartDate = scheduledStartDate;
    this.studentNote = studentNote;
    this.teacherNote = teacherNote;
  }
}

export class EventClientResponseModel {
  actualEndDate: any;
  actualStartDate: any;
  billAmount: number;
  eventStatusId: number;
  eventStatusIdEntity: string;
  eventStatusIdNavigation?: EventStatusClientResponseModel;
  id: number;
  scheduledEndDate: any;
  scheduledStartDate: any;
  studentNote: string;
  teacherNote: string;

  constructor() {
    this.actualEndDate = undefined;
    this.actualStartDate = undefined;
    this.billAmount = 0;
    this.eventStatusId = 0;
    this.eventStatusIdEntity = '';
    this.eventStatusIdNavigation = undefined;
    this.id = 0;
    this.scheduledEndDate = undefined;
    this.scheduledStartDate = undefined;
    this.studentNote = '';
    this.teacherNote = '';
  }

  setProperties(
    actualEndDate: any,
    actualStartDate: any,
    billAmount: number,
    eventStatusId: number,
    id: number,
    scheduledEndDate: any,
    scheduledStartDate: any,
    studentNote: string,
    teacherNote: string
  ): void {
    this.actualEndDate = actualEndDate;
    this.actualStartDate = actualStartDate;
    this.billAmount = billAmount;
    this.eventStatusId = eventStatusId;
    this.id = id;
    this.scheduledEndDate = scheduledEndDate;
    this.scheduledStartDate = scheduledStartDate;
    this.studentNote = studentNote;
    this.teacherNote = teacherNote;
  }
}
export class EventStatusClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class EventStatusClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class EventStudentClientRequestModel {
  eventId: number;
  eventIdEntity: string;
  eventIdNavigation?: EventClientResponseModel;
  id: number;
  studentId: number;
  studentIdEntity: string;
  studentIdNavigation?: StudentClientResponseModel;

  constructor() {
    this.eventId = 0;
    this.eventIdEntity = '';
    this.eventIdNavigation = undefined;
    this.id = 0;
    this.studentId = 0;
    this.studentIdEntity = '';
    this.studentIdNavigation = undefined;
  }

  setProperties(eventId: number, id: number, studentId: number): void {
    this.eventId = eventId;
    this.id = id;
    this.studentId = studentId;
  }
}

export class EventStudentClientResponseModel {
  eventId: number;
  eventIdEntity: string;
  eventIdNavigation?: EventClientResponseModel;
  id: number;
  studentId: number;
  studentIdEntity: string;
  studentIdNavigation?: StudentClientResponseModel;

  constructor() {
    this.eventId = 0;
    this.eventIdEntity = '';
    this.eventIdNavigation = undefined;
    this.id = 0;
    this.studentId = 0;
    this.studentIdEntity = '';
    this.studentIdNavigation = undefined;
  }

  setProperties(eventId: number, id: number, studentId: number): void {
    this.eventId = eventId;
    this.id = id;
    this.studentId = studentId;
  }
}
export class EventTeacherClientRequestModel {
  id: number;
  idEntity: string;
  idNavigation?: EventClientResponseModel;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherClientResponseModel;

  constructor() {
    this.id = 0;
    this.idEntity = '';
    this.idNavigation = undefined;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
  }

  setProperties(id: number, teacherId: number): void {
    this.id = id;
    this.teacherId = teacherId;
  }
}

export class EventTeacherClientResponseModel {
  id: number;
  idEntity: string;
  idNavigation?: EventClientResponseModel;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherClientResponseModel;

  constructor() {
    this.id = 0;
    this.idEntity = '';
    this.idNavigation = undefined;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
  }

  setProperties(id: number, teacherId: number): void {
    this.id = id;
    this.teacherId = teacherId;
  }
}
export class FamilyClientRequestModel {
  id: number;
  note: string;
  primaryContactEmail: string;
  primaryContactFirstName: string;
  primaryContactLastName: string;
  primaryContactPhone: string;

  constructor() {
    this.id = 0;
    this.note = '';
    this.primaryContactEmail = '';
    this.primaryContactFirstName = '';
    this.primaryContactLastName = '';
    this.primaryContactPhone = '';
  }

  setProperties(
    id: number,
    note: string,
    primaryContactEmail: string,
    primaryContactFirstName: string,
    primaryContactLastName: string,
    primaryContactPhone: string
  ): void {
    this.id = id;
    this.note = note;
    this.primaryContactEmail = primaryContactEmail;
    this.primaryContactFirstName = primaryContactFirstName;
    this.primaryContactLastName = primaryContactLastName;
    this.primaryContactPhone = primaryContactPhone;
  }
}

export class FamilyClientResponseModel {
  id: number;
  note: string;
  primaryContactEmail: string;
  primaryContactFirstName: string;
  primaryContactLastName: string;
  primaryContactPhone: string;

  constructor() {
    this.id = 0;
    this.note = '';
    this.primaryContactEmail = '';
    this.primaryContactFirstName = '';
    this.primaryContactLastName = '';
    this.primaryContactPhone = '';
  }

  setProperties(
    id: number,
    note: string,
    primaryContactEmail: string,
    primaryContactFirstName: string,
    primaryContactLastName: string,
    primaryContactPhone: string
  ): void {
    this.id = id;
    this.note = note;
    this.primaryContactEmail = primaryContactEmail;
    this.primaryContactFirstName = primaryContactFirstName;
    this.primaryContactLastName = primaryContactLastName;
    this.primaryContactPhone = primaryContactPhone;
  }
}
export class RateClientRequestModel {
  amountPerMinute: number;
  id: number;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherClientResponseModel;
  teacherSkillId: number;
  teacherSkillIdEntity: string;
  teacherSkillIdNavigation?: TeacherSkillClientResponseModel;

  constructor() {
    this.amountPerMinute = 0;
    this.id = 0;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
    this.teacherSkillId = 0;
    this.teacherSkillIdEntity = '';
    this.teacherSkillIdNavigation = undefined;
  }

  setProperties(
    amountPerMinute: number,
    id: number,
    teacherId: number,
    teacherSkillId: number
  ): void {
    this.amountPerMinute = amountPerMinute;
    this.id = id;
    this.teacherId = teacherId;
    this.teacherSkillId = teacherSkillId;
  }
}

export class RateClientResponseModel {
  amountPerMinute: number;
  id: number;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherClientResponseModel;
  teacherSkillId: number;
  teacherSkillIdEntity: string;
  teacherSkillIdNavigation?: TeacherSkillClientResponseModel;

  constructor() {
    this.amountPerMinute = 0;
    this.id = 0;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
    this.teacherSkillId = 0;
    this.teacherSkillIdEntity = '';
    this.teacherSkillIdNavigation = undefined;
  }

  setProperties(
    amountPerMinute: number,
    id: number,
    teacherId: number,
    teacherSkillId: number
  ): void {
    this.amountPerMinute = amountPerMinute;
    this.id = id;
    this.teacherId = teacherId;
    this.teacherSkillId = teacherSkillId;
  }
}
export class SpaceClientRequestModel {
  description: string;
  id: number;
  name: string;

  constructor() {
    this.description = '';
    this.id = 0;
    this.name = '';
  }

  setProperties(description: string, id: number, name: string): void {
    this.description = description;
    this.id = id;
    this.name = name;
  }
}

export class SpaceClientResponseModel {
  description: string;
  id: number;
  name: string;

  constructor() {
    this.description = '';
    this.id = 0;
    this.name = '';
  }

  setProperties(description: string, id: number, name: string): void {
    this.description = description;
    this.id = id;
    this.name = name;
  }
}
export class SpaceFeatureClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class SpaceFeatureClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class SpaceSpaceFeatureClientRequestModel {
  id: number;
  spaceFeatureId: number;
  spaceFeatureIdEntity: string;
  spaceFeatureIdNavigation?: SpaceFeatureClientResponseModel;
  spaceId: number;
  spaceIdEntity: string;
  spaceIdNavigation?: SpaceClientResponseModel;

  constructor() {
    this.id = 0;
    this.spaceFeatureId = 0;
    this.spaceFeatureIdEntity = '';
    this.spaceFeatureIdNavigation = undefined;
    this.spaceId = 0;
    this.spaceIdEntity = '';
    this.spaceIdNavigation = undefined;
  }

  setProperties(id: number, spaceFeatureId: number, spaceId: number): void {
    this.id = id;
    this.spaceFeatureId = spaceFeatureId;
    this.spaceId = spaceId;
  }
}

export class SpaceSpaceFeatureClientResponseModel {
  id: number;
  spaceFeatureId: number;
  spaceFeatureIdEntity: string;
  spaceFeatureIdNavigation?: SpaceFeatureClientResponseModel;
  spaceId: number;
  spaceIdEntity: string;
  spaceIdNavigation?: SpaceClientResponseModel;

  constructor() {
    this.id = 0;
    this.spaceFeatureId = 0;
    this.spaceFeatureIdEntity = '';
    this.spaceFeatureIdNavigation = undefined;
    this.spaceId = 0;
    this.spaceIdEntity = '';
    this.spaceIdNavigation = undefined;
  }

  setProperties(id: number, spaceFeatureId: number, spaceId: number): void {
    this.id = id;
    this.spaceFeatureId = spaceFeatureId;
    this.spaceId = spaceId;
  }
}
export class StudentClientRequestModel {
  birthday: any;
  email: string;
  emailRemindersEnabled: boolean;
  familyId: number;
  familyIdEntity: string;
  familyIdNavigation?: FamilyClientResponseModel;
  firstName: string;
  id: number;
  isAdult: boolean;
  lastName: string;
  phone: string;
  smsRemindersEnabled: boolean;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.birthday = undefined;
    this.email = '';
    this.emailRemindersEnabled = false;
    this.familyId = 0;
    this.familyIdEntity = '';
    this.familyIdNavigation = undefined;
    this.firstName = '';
    this.id = 0;
    this.isAdult = false;
    this.lastName = '';
    this.phone = '';
    this.smsRemindersEnabled = false;
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    birthday: any,
    email: string,
    emailRemindersEnabled: boolean,
    familyId: number,
    firstName: string,
    id: number,
    isAdult: boolean,
    lastName: string,
    phone: string,
    smsRemindersEnabled: boolean,
    userId: number
  ): void {
    this.birthday = birthday;
    this.email = email;
    this.emailRemindersEnabled = emailRemindersEnabled;
    this.familyId = familyId;
    this.firstName = firstName;
    this.id = id;
    this.isAdult = isAdult;
    this.lastName = lastName;
    this.phone = phone;
    this.smsRemindersEnabled = smsRemindersEnabled;
    this.userId = userId;
  }
}

export class StudentClientResponseModel {
  birthday: any;
  email: string;
  emailRemindersEnabled: boolean;
  familyId: number;
  familyIdEntity: string;
  familyIdNavigation?: FamilyClientResponseModel;
  firstName: string;
  id: number;
  isAdult: boolean;
  lastName: string;
  phone: string;
  smsRemindersEnabled: boolean;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.birthday = undefined;
    this.email = '';
    this.emailRemindersEnabled = false;
    this.familyId = 0;
    this.familyIdEntity = '';
    this.familyIdNavigation = undefined;
    this.firstName = '';
    this.id = 0;
    this.isAdult = false;
    this.lastName = '';
    this.phone = '';
    this.smsRemindersEnabled = false;
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    birthday: any,
    email: string,
    emailRemindersEnabled: boolean,
    familyId: number,
    firstName: string,
    id: number,
    isAdult: boolean,
    lastName: string,
    phone: string,
    smsRemindersEnabled: boolean,
    userId: number
  ): void {
    this.birthday = birthday;
    this.email = email;
    this.emailRemindersEnabled = emailRemindersEnabled;
    this.familyId = familyId;
    this.firstName = firstName;
    this.id = id;
    this.isAdult = isAdult;
    this.lastName = lastName;
    this.phone = phone;
    this.smsRemindersEnabled = smsRemindersEnabled;
    this.userId = userId;
  }
}
export class StudioClientRequestModel {
  address1: string;
  address2: string;
  city: string;
  id: number;
  name: string;
  province: string;
  website: string;
  zip: string;

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

  setProperties(
    address1: string,
    address2: string,
    city: string,
    id: number,
    name: string,
    province: string,
    website: string,
    zip: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.city = city;
    this.id = id;
    this.name = name;
    this.province = province;
    this.website = website;
    this.zip = zip;
  }
}

export class StudioClientResponseModel {
  address1: string;
  address2: string;
  city: string;
  id: number;
  name: string;
  province: string;
  website: string;
  zip: string;

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

  setProperties(
    address1: string,
    address2: string,
    city: string,
    id: number,
    name: string,
    province: string,
    website: string,
    zip: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.city = city;
    this.id = id;
    this.name = name;
    this.province = province;
    this.website = website;
    this.zip = zip;
  }
}
export class TeacherClientRequestModel {
  birthday: any;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.birthday = undefined;
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    birthday: any,
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    phone: string,
    userId: number
  ): void {
    this.birthday = birthday;
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
    this.userId = userId;
  }
}

export class TeacherClientResponseModel {
  birthday: any;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserClientResponseModel;

  constructor() {
    this.birthday = undefined;
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    birthday: any,
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    phone: string,
    userId: number
  ): void {
    this.birthday = birthday;
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
    this.userId = userId;
  }
}
export class TeacherSkillClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class TeacherSkillClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class TeacherTeacherSkillClientRequestModel {
  id: number;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherClientResponseModel;
  teacherSkillId: number;
  teacherSkillIdEntity: string;
  teacherSkillIdNavigation?: TeacherSkillClientResponseModel;

  constructor() {
    this.id = 0;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
    this.teacherSkillId = 0;
    this.teacherSkillIdEntity = '';
    this.teacherSkillIdNavigation = undefined;
  }

  setProperties(id: number, teacherId: number, teacherSkillId: number): void {
    this.id = id;
    this.teacherId = teacherId;
    this.teacherSkillId = teacherSkillId;
  }
}

export class TeacherTeacherSkillClientResponseModel {
  id: number;
  teacherId: number;
  teacherIdEntity: string;
  teacherIdNavigation?: TeacherClientResponseModel;
  teacherSkillId: number;
  teacherSkillIdEntity: string;
  teacherSkillIdNavigation?: TeacherSkillClientResponseModel;

  constructor() {
    this.id = 0;
    this.teacherId = 0;
    this.teacherIdEntity = '';
    this.teacherIdNavigation = undefined;
    this.teacherSkillId = 0;
    this.teacherSkillIdEntity = '';
    this.teacherSkillIdNavigation = undefined;
  }

  setProperties(id: number, teacherId: number, teacherSkillId: number): void {
    this.id = id;
    this.teacherId = teacherId;
    this.teacherSkillId = teacherSkillId;
  }
}
export class UserClientRequestModel {
  id: number;
  password: string;
  username: string;

  constructor() {
    this.id = 0;
    this.password = '';
    this.username = '';
  }

  setProperties(id: number, password: string, username: string): void {
    this.id = id;
    this.password = password;
    this.username = username;
  }
}

export class UserClientResponseModel {
  id: number;
  password: string;
  username: string;

  constructor() {
    this.id = 0;
    this.password = '';
    this.username = '';
  }

  setProperties(id: number, password: string, username: string): void {
    this.id = id;
    this.password = password;
    this.username = username;
  }
}


/*<Codenesium>
    <Hash>28ab9d146e8f480a22f8c04b0fd6715d</Hash>
</Codenesium>*/