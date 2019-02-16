export default class TeacherViewModel {
  birthday: any;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;
  userId: number;
  userIdEntity: string;

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

  setProperties(
    birthday: any,
    email: string,
    firstName: string,
    id: number,
    isDeleted: boolean,
    lastName: string,
    phone: string,
    tenantId: number,
    userId: number
  ): void {
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


/*<Codenesium>
    <Hash>566a3934d68de89d06745147f738ca0f</Hash>
</Codenesium>*/