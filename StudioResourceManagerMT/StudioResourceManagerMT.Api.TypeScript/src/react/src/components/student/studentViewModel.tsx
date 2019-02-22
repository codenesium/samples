import moment from 'moment';

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
    this.birthday = moment(birthday, 'YYYY-MM-DD');
    this.email = moment(email, 'YYYY-MM-DD');
    this.emailRemindersEnabled = moment(emailRemindersEnabled, 'YYYY-MM-DD');
    this.familyId = moment(familyId, 'YYYY-MM-DD');
    this.firstName = moment(firstName, 'YYYY-MM-DD');
    this.id = moment(id, 'YYYY-MM-DD');
    this.isAdult = moment(isAdult, 'YYYY-MM-DD');
    this.lastName = moment(lastName, 'YYYY-MM-DD');
    this.phone = moment(phone, 'YYYY-MM-DD');
    this.smsRemindersEnabled = moment(smsRemindersEnabled, 'YYYY-MM-DD');
    this.userId = moment(userId, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>87ce6b7900116b29dd42ac7d506911fd</Hash>
</Codenesium>*/