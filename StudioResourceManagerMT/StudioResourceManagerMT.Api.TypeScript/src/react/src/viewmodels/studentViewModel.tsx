export default class StudentViewModel {
  birthday: any;
  email: string;
  emailRemindersEnabled: boolean;
  familyId: number;
  familyIdEntity: string;
  firstName: string;
  id: number;
  isAdult: boolean;
  lastName: string;
  phone: string;
  smsRemindersEnabled: boolean;
  userId: number;
  userIdEntity: string;

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

  setProperties(
    birthday: any,
    email: string,
    emailRemindersEnabled: boolean,
    familyId: number,
    firstName: string,
    id: number,
    isAdult: boolean,
    isDeleted: boolean,
    lastName: string,
    phone: string,
    smsRemindersEnabled: boolean,
    tenantId: number,
    userId: number
  ): void {
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


/*<Codenesium>
    <Hash>d061742ad419516d9e267dab128fa01d</Hash>
</Codenesium>*/