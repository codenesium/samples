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
    this.id = moment(id, 'YYYY-MM-DD');
    this.lastName = lastName;
    this.phone = phone;
  }

  toDisplay(): string {
    return String(this.email);
  }
}


/*<Codenesium>
    <Hash>3d46fd6ab4815cd3ff7836f77819e761</Hash>
</Codenesium>*/