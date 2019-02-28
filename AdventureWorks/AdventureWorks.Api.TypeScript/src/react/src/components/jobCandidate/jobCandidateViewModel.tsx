import moment from 'moment'
import EmployeeViewModel from '../employee/employeeViewModel'
	

export default class JobCandidateViewModel {
    businessEntityID:any;
businessEntityIDEntity : string;
businessEntityIDNavigation? : EmployeeViewModel;
jobCandidateID:number;
modifiedDate:any;
resume:string;

    constructor() {
		this.businessEntityID = undefined;
this.businessEntityIDEntity = '';
this.businessEntityIDNavigation = new EmployeeViewModel();
this.jobCandidateID = 0;
this.modifiedDate = undefined;
this.resume = '';

    }

	setProperties(businessEntityID : any,jobCandidateID : number,modifiedDate : any,resume : string) : void
	{
		this.businessEntityID = moment(businessEntityID,'YYYY-MM-DD');
this.jobCandidateID = moment(jobCandidateID,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.resume = moment(resume,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>f80560a55f318e83c0298ec7424d216f</Hash>
</Codenesium>*/