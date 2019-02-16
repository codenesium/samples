import FamilyViewModel from '../family/familyViewModel';
import UserViewModel from '../user/userViewModel';

export default class StudentViewModel {
  birthday: any;
  email: string;
  emailRemindersEnabled: boolean;
  familyId: number;
  familyIdEntity: string;
  familyIdNavigation?: FamilyViewModel;
  firstName: string;
  id: number;
  isAdult: boolean;
  lastName: string;
  phone: string;
  smsRemindersEnabled: boolean;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserViewModel;

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

  toDisplay(): string {
    return String(this.lastName);
  }
}


/*<Codenesium>
    <Hash>c623e7070b5e78e850f24a4a53d91a2c</Hash>
</Codenesium>*/