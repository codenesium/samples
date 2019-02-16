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
    <Hash>3ad4380586047c313652ace0d6f192ec</Hash>
</Codenesium>*/