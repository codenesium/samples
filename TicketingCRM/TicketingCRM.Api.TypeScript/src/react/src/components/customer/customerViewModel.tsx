import moment from 'moment';

export default class CustomerViewModel {
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;

  constructor() {
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
  }

  setProperties(
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    phone: string
  ): void {
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
  }

  toDisplay(): string {
    return String(this.email);
  }
}


/*<Codenesium>
    <Hash>02229d04e28ed4136a5cd112b6060818</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/