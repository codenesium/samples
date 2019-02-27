import moment from 'moment';

export default class OfficerViewModel {
  badge: string;
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  password: string;

  constructor() {
    this.badge = '';
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.password = '';
  }

  setProperties(
    badge: string,
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    password: string
  ): void {
    this.badge = badge;
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.password = password;
  }

  toDisplay(): string {
    return String(this.badge);
  }
}


/*<Codenesium>
    <Hash>b141b3794de4e37cfaecacaea482cd36</Hash>
</Codenesium>*/