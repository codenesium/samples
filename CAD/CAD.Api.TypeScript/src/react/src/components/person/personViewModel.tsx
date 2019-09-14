import moment from 'moment';

export default class PersonViewModel {
  firstName: string;
  id: number;
  lastName: string;
  phone: string;
  ssn: string;

  constructor() {
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
    this.ssn = '';
  }

  setProperties(
    firstName: string,
    id: number,
    lastName: string,
    phone: string,
    ssn: string
  ): void {
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
    this.ssn = ssn;
  }

  toDisplay(): string {
    return String(this.lastName);
  }
}


/*<Codenesium>
    <Hash>5daa843b7aad537c36e2a52710b5aae4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/