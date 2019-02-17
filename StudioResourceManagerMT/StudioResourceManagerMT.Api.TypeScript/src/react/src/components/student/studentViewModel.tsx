export default class StudentViewModel {
  birthday: any;
  email: string;
  emailRemindersEnabled: boolean;
  familyId: number;
  firstName: string;
  id: number;
  isAdult: boolean;
  lastName: string;
  phone: string;
  smsRemindersEnabled: boolean;
  userId: number;

  constructor() {
    this.birthday = undefined;
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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>1d01114b7389c91d4ab03f5413deec9d</Hash>
</Codenesium>*/