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
    return String(this.email);
  }
}


/*<Codenesium>
    <Hash>f33634b6267c6c4305aefad1e789bc5a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/