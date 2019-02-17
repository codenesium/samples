export default class AdminViewModel {
  birthday: any;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;
  userId: number;

  constructor() {
    this.birthday = undefined;
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
    this.userId = 0;
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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>23ad54ef6863ae009c47bb035c3e8746</Hash>
</Codenesium>*/