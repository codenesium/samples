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
    return String(this.lastName);
  }
}


/*<Codenesium>
    <Hash>74b02d1294d01f99c6445a7825bc1770</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/