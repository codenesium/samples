import moment from 'moment';

export default class HandlerViewModel {
  countryId: number;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;

  constructor() {
    this.countryId = 0;
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
  }

  setProperties(
    countryId: number,
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    phone: string
  ): void {
    this.countryId = countryId;
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
    <Hash>9c1f018280c704b4b5175e7da002799e</Hash>
</Codenesium>*/