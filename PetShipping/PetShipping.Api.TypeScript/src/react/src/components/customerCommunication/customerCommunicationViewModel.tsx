import moment from 'moment';
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
  notes: string;

  constructor() {
    this.customerId = 0;
    this.customerIdEntity = '';
    this.customerIdNavigation = undefined;
    this.dateCreated = undefined;
    this.employeeId = 0;
    this.employeeIdEntity = '';
    this.employeeIdNavigation = undefined;
    this.id = 0;
    this.notes = '';
  }

  setProperties(
    customerId: number,
    dateCreated: any,
    employeeId: number,
    id: number,
    notes: string
  ): void {
    this.customerId = customerId;
    this.dateCreated = moment(dateCreated, 'YYYY-MM-DD');
    this.employeeId = employeeId;
    this.id = id;
    this.notes = notes;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>f74f8dcbe93aaad12453ebb9f6c48815</Hash>
</Codenesium>*/