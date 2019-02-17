export default class AdminViewModel {
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  password: string;
  phone: string;
  username: string;

  constructor() {
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.password = '';
    this.phone = '';
    this.username = '';
  }

  setProperties(
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    password: string,
    phone: string,
    username: string
  ): void {
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.password = password;
    this.phone = phone;
    this.username = username;
  }

  toDisplay(): string {
    return String(this.username);
  }
}


/*<Codenesium>
    <Hash>4e10ca9e1349da040f177a6dbb37d243</Hash>
</Codenesium>*/