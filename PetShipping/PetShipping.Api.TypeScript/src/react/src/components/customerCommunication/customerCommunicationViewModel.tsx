import CustomerViewModel from '../customer/customerViewModel';
import EmployeeViewModel from '../employee/employeeViewModel';

export default class CustomerCommunicationViewModel {
  customerId: number;
  customerIdEntity: string;
  customerIdNavigation?: CustomerViewModel;
  dateCreated: any;
  employeeId: number;
  employeeIdEntity: string;
  employeeIdNavigation?: EmployeeViewModel;
  id: number;
  note: string;

  constructor() {
    this.customerId = 0;
    this.customerIdEntity = '';
    this.customerIdNavigation = undefined;
    this.dateCreated = undefined;
    this.employeeId = 0;
    this.employeeIdEntity = '';
    this.employeeIdNavigation = undefined;
    this.id = 0;
    this.note = '';
  }

  setProperties(
    customerId: number,
    dateCreated: any,
    employeeId: number,
    id: number,
    note: string
  ): void {
    this.customerId = customerId;
    this.dateCreated = dateCreated;
    this.employeeId = employeeId;
    this.id = id;
    this.note = note;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>9c8618d4627c75d2fad3f685cec4a9f2</Hash>
</Codenesium>*/