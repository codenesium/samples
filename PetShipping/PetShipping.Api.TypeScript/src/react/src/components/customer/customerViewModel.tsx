import moment from 'moment';

export default class CustomerViewModel {
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  notes: string;
  phone: string;

  constructor() {
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.notes = '';
    this.phone = '';
  }

  setProperties(
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    notes: string,
    phone: string
  ): void {
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.notes = notes;
    this.phone = phone;
  }

  toDisplay(): string {
    return String(this.email);
  }
}


/*<Codenesium>
    <Hash>9b4ab007eba05861c5697a9044769a51</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/