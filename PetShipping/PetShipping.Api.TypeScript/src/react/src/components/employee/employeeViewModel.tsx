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
    this.firstName = moment(firstName, 'YYYY-MM-DD');
    this.id = moment(id, 'YYYY-MM-DD');
    this.isSalesPerson = moment(isSalesPerson, 'YYYY-MM-DD');
    this.isShipper = moment(isShipper, 'YYYY-MM-DD');
    this.lastName = moment(lastName, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>9480e428b72c951379343279601bc2ff</Hash>
</Codenesium>*/