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
    return String();
  }
}


/*<Codenesium>
    <Hash>ecadd5bbd9b3f9063925a6faaa4c2834</Hash>
</Codenesium>*/