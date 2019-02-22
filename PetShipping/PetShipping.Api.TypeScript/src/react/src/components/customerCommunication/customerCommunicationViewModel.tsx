import moment from 'moment'
import CustomerViewModel from '../customer/customerViewModel'
	import EmployeeViewModel from '../employee/employeeViewModel'
	

export default class CustomerCommunicationViewModel {
    customerId:number;
customerIdEntity : string;
customerIdNavigation? : CustomerViewModel;
dateCreated:any;
employeeId:number;
employeeIdEntity : string;
employeeIdNavigation? : EmployeeViewModel;
id:number;
note:string;

    constructor() {
		this.customerId = 0;
this.customerIdEntity = '';
this.customerIdNavigation = new CustomerViewModel();
this.dateCreated = undefined;
this.employeeId = 0;
this.employeeIdEntity = '';
this.employeeIdNavigation = new EmployeeViewModel();
this.id = 0;
this.note = '';

    }

	setProperties(customerId : number,dateCreated : any,employeeId : number,id : number,note : string) : void
	{
		this.customerId = moment(customerId,'YYYY-MM-DD');
this.dateCreated = moment(dateCreated,'YYYY-MM-DD');
this.employeeId = moment(employeeId,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.note = moment(note,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>aa618e7ee98f654ddb54e55deb0b2ad2</Hash>
</Codenesium>*/