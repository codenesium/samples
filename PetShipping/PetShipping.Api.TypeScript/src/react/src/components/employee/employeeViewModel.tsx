import moment from 'moment';

export default class EmployeeViewModel {
  firstName: string;
  id: number;
  isSalesPerson: boolean;
  isShipper: boolean;
  lastName: string;

  constructor() {
    this.firstName = '';
    this.id = 0;
    this.isSalesPerson = false;
    this.isShipper = false;
    this.lastName = '';
  }

  setProperties(
    firstName: string,
    id: number,
    isSalesPerson: boolean,
    isShipper: boolean,
    lastName: string
  ): void {
    this.firstName = firstName;
    this.id = id;
    this.isSalesPerson = isSalesPerson;
    this.isShipper = isShipper;
    this.lastName = lastName;
  }

  toDisplay(): string {
    return String(this.firstName);
  }
}


/*<Codenesium>
    <Hash>bc756d1a7fcaa32642ea7494fe024177</Hash>
</Codenesium>*/