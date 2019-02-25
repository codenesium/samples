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
    return String();
  }
}


/*<Codenesium>
    <Hash>c9df38ecbd623d5a9e8c837e0fb7392c</Hash>
</Codenesium>*/