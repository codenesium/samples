import moment from 'moment';

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
    <Hash>1510202ae6aef17d3a4b9c23e3bb4835</Hash>
</Codenesium>*/