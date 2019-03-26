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
    return String(this.firstName);
  }
}


/*<Codenesium>
    <Hash>962fb9aa92fec2c2548ad8df81c30ae8</Hash>
</Codenesium>*/