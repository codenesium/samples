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
		this.customerId = customerId;
this.dateCreated = moment(dateCreated,'YYYY-MM-DD');
this.employeeId = employeeId;
this.id = id;
this.note = note;

	}

	toDisplay() : string
	{
		return String(this.customerId);
	}
};

/*<Codenesium>
    <Hash>3b5c77fccb0ae4383b3701731532f9e3</Hash>
</Codenesium>*/